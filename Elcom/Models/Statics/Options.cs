using System;
using System.Collections.Generic;
using System.Data;
// ReSharper disable All

namespace Elcom.Models
{
    /// <summary>
    /// Общий класс, который будет вмещать в себе все попапы и опшенлисты, дабы не обращаться постоянно к базе. Обновить все попапы можно через UpdateAllOptions()
    /// </summary>
    public static class Options
    {
        // Список складов.
        public static List<Inventory> Inventories;

        // Массив должностей
        public static readonly SheetList Sheets = new SheetList();
        
        public static void UpdateAllOptions()
        {
            // Заполняем список складов согласно текущим данным из базы
            UpdateOptions<Inventory>(@"select InventoryNumber, InventoryName from Inventory order by decode(telex,' ',999,to_number_m(telex)) asc, InventoryNumber ", ref Inventories);
            
            Sheets.Update();
            
            Console.WriteLine("Списки опций обновлены!");
        }

        public static void UpdateEmployees()
        {
            //UpdateOptions<Inventory>(@"select DISTINCT Role From Optionlist where type = Employee ", ref Employees);

            Console.WriteLine("Данные о доступах ролей обновлены!");
        }

        // Универсальный класс для заполнения списков опций. 
        //<T> - Обобщение, where T : OptionList, new() - так T гарантирует, что будет иметь конструктор без параметров и будет наследоваться от OptionList. 
        // Благодаря этому мы сможем создать новые экземпляры напрямую из этого метода.
        static void UpdateOptions<T> (string SqlString, ref List<T> list) where T : IOptionList, new()
        {
            //Очищаем массив 
            if (list is null)
                list = new List<T>();
            else 
                list.Clear();
            // Вносим в команду запрос для заполнения массива, возвращать будем таблицу
            var command = new TextCommand(SqlString, Returns.Table);
            var caller = new DbCaller(command, null, "Oracle");
            caller.DoWork();
            // Возвращаем результат каллера в виде датасета
            var dt = (DataTable)caller.GetResult();
            // Проходим по строчкам и вносим данные в массив
            foreach (DataRow row in dt.Rows)
            {
                // Создаем массив с размерностью строки
                object[] dsRow = new object[dt.Columns.Count];
                // Заполняем его согласно данным со столбцов
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dsRow[i] = row.ItemArray[i];
                }
                // Создаем экземпляр обобщенного класса
                var newElem = new T();
                // Вносим в него данные, передав ему свежесозданный массив объектов
                newElem.CreateFromArray(dsRow);
                // Вносим экзепляр в целевой массив
                list.Add(newElem);
            }
        }
    }
}
