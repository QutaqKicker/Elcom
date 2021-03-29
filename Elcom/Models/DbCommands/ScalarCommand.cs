using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Elcom.Models
{
    //Текстовая команда, возвращающая скалярное значение. Принимает только текст процедуры
    public class ScalarCommand : dbCommand
    {
        public ScalarCommand(string sqlString)
        {
            SqlString = sqlString;
            CommandType = CommandType.Text;
            Returns = Returns.Scalar;
        }
    }
}
