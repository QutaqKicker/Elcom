using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    /// <summary>
    /// Команда, принимающая множество значений. Принимает большую строку с элементами, разделенными \n и самостоятельно разделяет ее. 
    /// </summary>
    public class ArrayCommand : dbCommand
    {
        public readonly string[] Values;

        public ArrayCommand(string sqlString, Returns returnable = Returns.Scalar)
        {
            Values = sqlString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            SqlString = sqlString;
            CommandType = CommandType.StoredProcedure;
            Returns = returnable;
        }
    }
}
