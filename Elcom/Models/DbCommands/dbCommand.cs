using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
    // Возвращаемый тип
    public enum Returns { Nothing, Scalar, DataSet, ImportFile, Table }
    /// <summary>
    /// Каркас для классов команд. Здесь хранится основная информация о запросе
    /// </summary>
    public abstract class dbCommand
    {
        public string SqlString;
        public CommandType CommandType;
        public Param[] Parameters;

        /// <summary>
        /// Позволяет выбрать, вернет ли процедура что-то
        /// </summary>
        public Returns Returns;
    }
}
