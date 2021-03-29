using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    /// <summary>
    /// Текстовый запрос к базе
    /// </summary>
    public class TextCommand : dbCommand
    {
        public TextCommand(string sqlString, Returns returnable = Returns.Table)
        {
            SqlString = sqlString;
            CommandType = CommandType.Text;
            Returns = returnable;
        }
    }
}
