using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesignerApp
{
    static public class Helper
    {

        public static string GetPrimitiveMemberType(string typeCode)
        {
            switch (typeCode)
            {
                case "Boolean":
                    return "boolean";
                case "Byte":
                case "Decimal":
                case "Double":
                case "int":
                case "Int":
                case "Int16":
                case "Int32":
                case "Int64":
                case "SByte":
                case "Single":
                case "UInt16":
                case "UInt32":
                case "UInt64":
                    return "number";
                case "Char":
                case "char":
                case "String":
                case "string":
                    return "string";
                case "DateTime":
                case "Date":
                    return "Date";
                default:
                    return typeCode;
            }

        }

        /*
                 public static string GetPrimitiveMemberType(TypeCode typeCode)
                {
                    switch (typeCode)
                    {
                        case TypeCode.Boolean:
                            return "boolean";
                        case TypeCode.Byte:
                        case TypeCode.Decimal:
                        case TypeCode.Double:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.SByte:
                        case TypeCode.Single:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                            return "number";
                        case TypeCode.Char:
                        case TypeCode.String:
                            return "string";
                        case TypeCode.DateTime:
                            return "Date";
                        default:
                            return "any";
                    }

                }

         */
    }
}

