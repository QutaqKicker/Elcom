using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    public class SheetList : IEnumerable<Sheet>
    {
        private List<Sheet> _sheetList = new List<Sheet>();

        public Sheet this[int index] => _sheetList[index];

        public Sheet this[string name] => _sheetList.FirstOrDefault(x => x.Name.Equals(name)) ?? _sheetList.FirstOrDefault(x => x.Description == name);

        public Sheet this[string description, string accessLevel] => _sheetList.Where(x => x.Description == description).FirstOrDefault(x => x.AccessLevel == accessLevel);


        public IEnumerator<Sheet> GetEnumerator()
        {
            return _sheetList.GetEnumerator();
        }

        public void Update()
        {
            // Получаем результирующий набор всех листов по доступам
            //TODO Ввести актуальный запрос
            var command = new TextCommand(@"SELECT Description, Remark1, Remark2, Remark3 FROM elco.THEOPTION WHERE OPTIONLISTNUMBER = 'CMACROS'", Returns.Table);
            var caller = new DbCaller(command);
            DataTable table = (DataTable)caller.DoWork();

            foreach (DataRow row in table.Rows)
            {
                // Создаем лист 
                var sheet = new Sheet(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                //Выгружаем экшены для этого листа
                //TODO Ввести актуальный запрос
                var actionsCommand = new TextCommand(@"SELECT Description, Remark1, Remark2, Remark3 FROM elco.THEOPTION WHERE OPTIONLISTNUMBER = 'CMACROS'", Returns.Table);
                var actionsCaller = new DbCaller(actionsCommand);
                DataTable actionsTable = (DataTable)actionsCaller.DoWork();
                foreach (DataRow actionRow in actionsTable.Rows)
                {
                    var action = new Action(actionRow[1].ToString(), int.Parse(actionRow[2].ToString()), actionRow[2].ToString(), actionRow[3].ToString());
                    //Выгружаем параметры для этого экшена
                    //TODO Ввести актуальный запрос
                    var paramsCommand = new TextCommand(@"SELECT Description, Remark1, Remark2, Remark3 FROM elco.THEOPTION WHERE OPTIONLISTNUMBER = 'CMACROS'", Returns.Table);
                    var paramsCaller = new DbCaller(paramsCommand);
                    DataTable paramsTable = (DataTable)paramsCaller.DoWork();
                    foreach (DataRow paramRow in paramsTable.Rows)
                    {
                        action.parameters.Add(new Param(paramRow[1].ToString(), paramRow[2].ToString(), int.Parse(paramRow[3].ToString()), paramRow[4].ToString(), paramRow[5].ToString()));
                    }
                    sheet.Actions.Add(action);
                }
                //Добавляем в общий список листов готовый лист с экшенами и параметрами
                _sheetList.Add(sheet);
            }
        } 

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _sheetList.GetEnumerator();
        }
    }

    /// <summary>
    /// Класс должности. Хранит в себе название и список листов, которые ему доступны
    /// </summary>
    public class Employee
    {
        // Должность
        public string Position;
        // Список листов
        public List<Sheet> Sheets = new List<Sheet>();
        // Конструктор с должностью из перечисления
        public Employee(string position)
        {
            Position = position;
        }
        // Конструктор с названием должности из перечисления
        /*
        public Employee(string position)
        {
            // Насильно приводим строку позиции к виду перечисления и заносим в позицию
            Position = (Position)System.Enum.Parse(typeof(Position), position);
        }
        */
        /// <summary>
        /// Заносит список листов в должность
        /// </summary>
        public void SetSheets(List<Sheet> sheets)
        {
            Sheets = sheets;
        }

        /// <summary>
        /// Возвращает лист с указанным названием
        /// </summary>
        /// <param name="sheetName">Название искомого листа</param>
        public Sheet GetSheet(string sheetName)
        {
            var search = Sheets.FirstOrDefault(x => x.Description.Equals(sheetName));
            return search ?? Sheets.FirstOrDefault(x => x.Name.Equals(sheetName));
        }

        public Sheet this[string sheetName] => Sheets.FirstOrDefault(x => x.Description == sheetName);
    }

    //TODO переделать класс листов и экшенов согласно новому тз
    /// <summary>
    /// Класс листа. Хранит в себе название, описание на русском, название процедуры, которая его вызывает, параметры
    /// </summary>
    public class Sheet
    {
        public string Description;
        public string Procedure;
        public string AccessLevel;
        public string Name;
        public List<Action> Actions = new List<Action>();
        public Action this[int index] => Actions[index];

        public Sheet(string description, string procedure, string accessLevel, string name)
        {
            Name = name;
            Description = description;
            Procedure = procedure;
            AccessLevel = accessLevel;
        }
    }
}
