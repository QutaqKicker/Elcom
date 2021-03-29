using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class DbCaller
    {
        private readonly string _connectionString;
        private readonly dbCommand _dbCommand;
        private readonly DataWorker _dataWorker;
        private object _result;
        private string[] _ignoreColumns;

        public DbCaller(dbCommand dbCommand, DataWorker dataWorker = null, string dbType = "OracleTest")
        {
            _connectionString = GetConnectionString(dbType);
            _dbCommand = dbCommand;
            _dataWorker = dataWorker;
            _ignoreColumns = new string[] {};
        }
        
        // Возвращает результат работы запроса, если DataWorker не был выбран
        public object GetResult()
        {
            return _result;
        }
        
        /// <summary>
        /// Возвращает строку подключения Oracle|MySQL|OracleTest|PgSQL
        /// </summary>
        private static string GetConnectionString(string dbType)
        {
            switch (dbType)
            {
                case "Oracle":
                    return ConfigSpace.OracleConnection;
                case "MySQL":
                    return ConfigSpace.MySQLConnection;
                case "OracleTest":
                    return ConfigSpace.OracleTestConnection;
                case "PgSQL":
                    return ConfigSpace.PgSQLConnection;
                case "PgSQL2":
                    return ConfigSpace.PgSQLConnection2;
                    // Если база не найдена, пишем в строку подключения то, что дали.
                default:
                    return dbType;
            }   
        }

        /// <summary>
        /// Предназначен для множественного вызова по всем элементам массива
        /// </summary>
        public object[] DoWorkWithArray()
        {
            List<object> result = new List<object>();
            foreach (var item in ((ArrayCommand)_dbCommand).Values)
            {
                result.Add(DoWork(item));
            }
            return result.ToArray();
        }

        public object DoWork()
        {
            return DoWork(_dbCommand.SqlString);
        }
        /// <summary>
        /// Производит запрошенные действия с базой и при необходимости обрабатывает их с помощью DataWorker
        /// </summary>
        public object DoWork(string sqlString)
        {
            // Создаем подключение к базе и работаем через него
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                // Открываем подключение
                connection.Open();
                // Конструируем запрос к базе данных, отдавая ей строку запроса из ранее собранного класса, тип запроса и строку подключения. Переводим в запросе все русские строки в CHR. Спасибо конфликту кодировок
                var cmd = new OracleCommand(_dbCommand.SqlString, connection);
                cmd.CommandType = _dbCommand.CommandType;

                // Если это процедура, то берем все параметры процедуры, что были переданы ранее, и циклом помещаем их в процедуру
                if (_dbCommand.CommandType == CommandType.StoredProcedure & !(_dbCommand.Parameters is null))
                {
                    foreach (Param param in _dbCommand.Parameters)
                    {
                        cmd.Parameters.Add(param.Name, param.Type, param.Value, ParameterDirection.Input);
                    }
                }

                // Если обработчик есть, меняем возвращаемый тип на тот, который принимает обработчик
                if (_dataWorker != null)
                {
                    if (_dataWorker is ExcelWorker)
                        _dbCommand.Returns = Returns.DataSet;
                }

                switch (_dbCommand.Returns)
                {
                    // Если возврат не подразумевается, выполняем запрос и ничего не возвращаем. Простой апдейт, например
                    case Returns.Nothing:
                        cmd.ExecuteNonQuery();
                        break;

                    // Возвращаем результат, если запрос или функция возвращают какое-то одно поле. Например, номер найденного товара
                    case Returns.Scalar:
                        _result = Helper.ConvertFromOracle(cmd.ExecuteScalar().ToString());
                        break;

                    // Возвращаем датасет
                    case Returns.DataSet:
                        // Если обработчика нет, то результат запроса просто пихаем в поле для результата. Позже его можно будет извлечь соответствующей функцией
                        // Создаем адаптер и передаем ему необходимые данные. Он нам нужен для выгрузки всей нужной информации из базы разом, чтобы потом с ней можно было работать отдельно
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        // Заставляем адаптер работать, а весь результат работы складировать в заранее определенный DataSet. Это результирующий набор таблиц, которые мог вернуть запрос.
                        adapter.Fill(ds);
                        _result = Helper.ConvertTableFromOracle(ds);
                        break;

                    // Возвращаем Таблицу
                    case Returns.Table:
                        OracleDataAdapter tableAdapter = new OracleDataAdapter(cmd);
                        DataSet tableDs = new DataSet();
                        // Заставляем адаптер работать, а весь результат работы складировать в DataTable.
                        tableAdapter.Fill(tableDs);
                        // Берем первую таблицу из датасета
                        _result = Helper.ConvertTableFromOracle(tableDs.Tables[0]);
                        foreach (string col in _ignoreColumns)
                        {
                            ((DataTable)_result).Columns.Remove(col);
                        }
                        break;
                }

                // Если обработчик есть, то передаем ему датасет и заставляем работать
                if (_dataWorker != null)
                {
                    // Если есть параметры, то вносим их в воркер для последующего вывода
                    if (!(_dbCommand.Parameters is null))
                        if (_dbCommand.Parameters.Count() > 0)
                            ((ExcelWorker)_dataWorker).SetParamForView(_dbCommand.Parameters);

                    _dataWorker.DoWork((DataSet)_result);
                    // Результат работы помещаем в поле для результата, предварительно приведя его к ЭксельВоркеру(Если работаем с ним), чтобы оттуда можно было извлечь данные
                    if (_dataWorker is ExcelWorker)
                    {
                        _result = ((ExcelWorker)_dataWorker).GetFile();
                        //FileOnBytea = ((ExcelWorker)DataWorker).FilledBytes;
                    }
                        
                }
                connection.Close();
            }
            return _result;
        }
    }
}
