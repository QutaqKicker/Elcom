using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    /// <summary>
    /// Запрос в виде функции
    /// </summary>
    public class FunctionCommand : dbCommand
    {
        readonly string _name;

        public FunctionCommand(string procName, Param[] parameters = null, Returns returnable = Returns.Table)
        {
            _name = procName;
            // Имеет тип текст, так как вытаскивать будем через селект. Тип процедуры не прокатывает
            CommandType = CommandType.Text;
            Parameters = parameters;
            Returns = returnable;
            // Приводим имеющиеся данные к вызову в виде селекта
            TransferFunctionToText();
        }

        private void TransferFunctionToText()
        {
            // Если параметры указаны, то делаем из них строку типа (Значение1, Значение2, Значение3)
            var Params = "";
            if (!(Parameters is null))
            {
                foreach (Param param in Parameters)
                {
                    // Тип заранее неизвестен, так что все значения по дефолту будут строками. Оракл, вроде как, должен привести строку к нужному типу
                    Params += '\'' + param.Value.ToString() + "\',";
                }
                // Окружаем скобками и вырезаем последнюю запятую
                Params = "(" + Params.TrimEnd(',') + ")";
            }
            SqlString = "select * from " + _name.Replace(")", Params + ") where rownum < 10");
        }
    }
}
