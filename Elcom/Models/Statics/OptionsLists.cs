using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    /// <summary>
    /// Обеспечивает возможность создания нового класса из обобщающего метода
    /// </summary>
    public interface IOptionList
    {
        /// <summary>
        /// Заполняет поля класса через массив объектов. Объекты нужно явно привести к нужному типу и строго по порядку присвоить полям класса
        /// </summary>
        /// <param name="readerRow">Массив объектов, полученных из запроса</param>
        void CreateFromArray(object[] readerRow);
    }

    // Класс склада. Из него будет состоять массив складов. Наследуем от интерфейса OptionList чтобы можно было создавать новые экземпляры через обобщающий метод
    public class Inventory : IOptionList
    {
        public int Number;
        public string Name;

        // Вносим в класс данные согласно входному массиву. Все элементы массива насильно приводим к нужному типу. Если не удается, ошибка в запросе или порядке столбцов
        public void CreateFromArray(object[] readerRow)
        {
            Number = int.Parse(readerRow[0].ToString());
            Name = (string)readerRow[1];
        }
    }
}
