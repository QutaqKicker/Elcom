using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    /// <summary>
    /// Запрос в виде процедуры
    /// </summary>
    public class ProcedureCommand : dbCommand
    {
        public ProcedureCommand(string procName, Param[] parameters = null, Returns returnable = Returns.Scalar)
        {
            SqlString = procName;
            CommandType = CommandType.StoredProcedure;
            Parameters = parameters;
            Returns = returnable;
        }
    }
}
