using NpgsqlTypes;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Elcom.Models
{
        public enum ParameterType{ Date, Text , Hidden }
        public enum ElementType { Input, Select }
        
        public enum ActionType { GetReport, UpdateDB }
        /// <summary>
        /// Класс параметра, хранит название параметра и значение(в виде объекта)
        /// </summary>
    public class Param
    {
        public string Name;
        public int Id;
        public object Value;
        public OracleDbType Type;
        public string Description;
        public ParameterType ParameterType;
        public ElementType ElementType;
        public string HintText;
        public bool Required;
        public Param(string paramName, object paramValue, string desc = null, OracleDbType type = OracleDbType.Varchar2)
        {
            Name = paramName;
            Value = paramValue;
            Type = type;
            Description = desc ?? Name;
        }

        public Param(ParameterType parameterType, ElementType elementType, int id, string value, string desc = "", string hintText = "", bool required = true)
        {
                Type = OracleDbType.Varchar2;
                Id = id;
                Name = desc;
                Value = value;
                ParameterType = parameterType;
                ElementType = elementType;
                Description = desc;
                HintText = hintText;
                Required = required;
        }
        public Param(string parameterType, string elementType, int id, string value, string desc = "", string hintText = "", bool required = true)
        {
                Type = OracleDbType.Varchar2;
                Id = id;
                Name = desc;
                Value = value;
                ParameterType = (ParameterType)System.Enum.Parse(typeof(ParameterType), parameterType);
                ElementType = (ElementType)System.Enum.Parse(typeof(ElementType), elementType);
                Description = desc;
                HintText = hintText;
                Required = required;
        }

        public string GetType()
        {
                return Enum.GetName(typeof(ParameterType), Convert.ToInt32(ParameterType))?.ToLower();
        }
    }
        
    /// <summary>
    /// Класс Action для нового функционала. Пока ничего не работает, ничего не согласовано
    /// </summary>
        public class Action
        {
                public string NameRus;
                public int Id;
                public ActionType ActionType;
                public string FunctionName;
                public List<Param> parameters;

                public Action(string name, int id, ActionType actionType, string function)
                {
                        NameRus = name;
                        Id = id;
                        ActionType = actionType;
                        FunctionName = function;
                }
                public Action(string name, int id, string actionType, string function)
                {
                        NameRus = name;
                        Id = id;
                        ActionType = (ActionType)System.Enum.Parse(typeof(ActionType), actionType);
                        FunctionName = function;
                }
        }
}
