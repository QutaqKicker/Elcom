using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elcom.Models
{
    // Режим импорта. CreateChange обьединяет Create и Change
    public enum ImportMode { Create, Change, CreateChange, Delete }

    /// <summary>
    /// Столбец файла импорта
    /// </summary>
    public class ImportColumn
    {
        public string Name;
        // Значение по умолчанию
        public string DefaultValue;
        // Значения в столбце
        public string[] Values;
        /// <summary>
        /// Создает столбец с введенным названием и значениями. Значения делит через перевод каретки. Если после этого остается только одно значение, оно берется как значение по умолчанию
        /// </summary>
        /// <param name="name">Название столбца</param>
        /// <param name="values">Значения столбца, разделенные через /n, либо одно значение по умолчанию</param>
        public ImportColumn(string name, string values)
        {
            Name = name;
            // Делим по \n, а если элемент один, берем его как значение по умолчанию
            Values = values.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            if (Values.Count() <= 1)
                DefaultValue = values;
        }
        
        public string this[int i]
        {
            get => Values[i];
            set => Values[i] = value;
        }
    }

    /// <summary>
    /// Секция импорта. Представляет из себя таблицу, импортящую нужные данные в определенную таблицу
    /// </summary>
    public class ImportSection
    {
        DataTable Section;

        /// <summary>
        /// Получить готовую секцию
        /// </summary>
        public DataTable GetSection()
        {
            return Section;
        }

        /// <summary>
        /// Создает новую секцию по названию таблицы, режиму импорта, используя введенный список столбцов
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        /// <param name="mode">Режим</param>
        /// <param name="list">Список столбцов</param>
        public ImportSection(string tableName, ImportMode mode, List<ImportColumn> list)
        {
            Section = new DataTable(tableName);
            
            // Вносим в секцию столько столбцов, сколько задействовано при импорте
            for(int j = 0; j <= list.Count; j++)
            {
                Section.Columns.Add(new DataColumn(j.ToString()));
            }
            var currentColumn = 0;
            var i = 1;
            // Если создаем и изменяем, увеличиваем количество строк в два раза
            var countOfRows = mode != ImportMode.CreateChange ? list[0].Values.Length : list[0].Values.Length * 2;

            // Пилим и вносим самую первую строку
            DataRow row = Section.NewRow();
            row[0] = tableName + ":FORMAT";
            Section.Rows.Add(row);
            // Вносим в секцию все строки, заполняем самый первый столбец согласно режиму
            for (var j = 0; j < countOfRows; j++)
            {
                switch (mode)
                {
                    case ImportMode.Create:
                        // Создаем новую строку по образцу, заполняем первый элемент, пихаем в секцию. И так будет с каждым...
                        row = Section.NewRow();
                        row[0] = tableName + ":CREATE";
                        Section.Rows.Add(row);
                        break;
                    case ImportMode.Change:
                        row = Section.NewRow();
                        row[0] = tableName + ":CHANGE";
                        Section.Rows.Add(row);
                        break;
                    case ImportMode.CreateChange:
                        var newRow1 = Section.NewRow();
                        newRow1[0] = tableName + ":CREATE";
                        var newRow2 = Section.NewRow();
                        newRow2[0] = tableName + ":CHANGE";
                        Section.Rows.Add(newRow1);
                        Section.Rows.Add(newRow2);
                        j++;
                        break;
                    case ImportMode.Delete:
                        row = Section.NewRow();
                        row[0] = tableName + ":DELETE";
                        Section.Rows.Add(row);
                        break;
                }
            }
            currentColumn++;
            foreach (ImportColumn col in list)
            {
                // Пилим все остальное
                i = 0;
                // Заполняем первую стркоу названиями столбцов
                Section.Rows[i++][currentColumn] = col.Name;
                // Если значение по умолчанию заполнено, заполняем ими столбец
                if (!(col.DefaultValue is null))
                {
                    for (i = 1; i <= countOfRows; i++)
                    {
                        Section.Rows[i][currentColumn] = col.DefaultValue;
                    }
                }
                // Если не заполнено, заполняем массивом значений
                else
                {
                    foreach (string item in col.Values)
                    {
                        if (mode == ImportMode.CreateChange)
                        {
                            Section.Rows[i++][currentColumn] = item;
                            Section.Rows[i++][currentColumn] = item;
                        }
                        else
                            Section.Rows[i++][currentColumn] = item;
                    }
                }
                currentColumn++;
            }
        }
    }

    /// <summary>
    /// Превращает введенные данные в файл импорта(В виде массива битов)
    /// </summary>
    public class ImportWorker : DataWorker
    {
        string _filePath;
        private byte[] _result;
        
        public ImportWorker(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Создает DataSet из набора секций
        /// </summary>
        public static DataSet CreateDataSet(IEnumerable<ImportSection> sections)
        {
            var ds = new DataSet();
            foreach (ImportSection section in sections)
            {
                ds.Tables.Add(section.GetSection());
            }
            return ds;
        }

        /// <summary>
        /// Принимает DataSet и пилит из него файл импорта, потом сохраняет его в виде массива битов в Result. Его извлечь можно через GetResult()
        /// </summary>
        public override void DoWork(DataSet ds)
        {
            StringBuilder str = new StringBuilder();
                // Создаем первый лист и начинаем работать с ним
                
            // Проходим по таблицам
            foreach (DataTable table in ds.Tables)
            {
                // Проходим по строкам в таблицах
                foreach(DataRow row in table.Rows)
                {
                    // Проходим по полям в строках
                    foreach(var item in row.ItemArray)
                    {
                        str.Append(item.ToString().Replace("\r", String.Empty) + '\t');
                    }
                    str.Append("\r\n");
                }
                // Переводим получившийся текст в массив битов
                var enc = Encoding.UTF8;
                _result = enc.GetBytes(str.ToString());
            }
            // Сохранение файла импорта в системе. Может пригодиться при отладке или в дальнейшем.
            //CreateFile();
            //using (var writer = new StreamWriter(new FileStream(FilePath, FileMode.Append, FileAccess.Write)))
            //{
            //    writer.WriteLine(str);
            //}
        }

        /// <summary>
        /// Перегрузка DoWork, позволяющая вместо набора секций использовать лишь одну без лишнего геморроя
        /// </summary>
        public void DoWork(ImportSection section)
        {
            List<ImportSection> sections = new List<ImportSection> {section};
            var ds = CreateDataSet(sections);
            DoWork(ds);
        }

        /// <summary>
        /// Возвращает результат работы DoWork
        /// </summary>
        public byte[] GetResult()
        {
            return _result;
        }

        /// <summary>
        /// Создает файл для файла импорта. Пока не используется
        /// </summary>
        public void CreateFile()
        {
            // Если такого файла нет, то копируем его шаблон в целевую папку,
            // если есть, то считаем сколько таких файлов есть и копируем его шаблон с крайним порядковым числом.
            // Метод возвращает название созданного файла
            if (!File.Exists(TempFilePath + Name + ".txt"))
            {
                File.Create(ImportPath + Name + ".txt").Close();
                _filePath = ImportPath + Name + ".txt";
            }
            else
            {
                var i = 1;
                while (File.Exists(ImportPath + Name + i + ".txt"))
                {
                    i++;
                }
                File.Create(ImportPath + Name + i + ".txt").Close();
                _filePath = ImportPath + Name + i + ".txt";
            }
        }
    }
}
