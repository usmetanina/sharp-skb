using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Files
{
    class Converter
    {
        public object Convert(string propName, string value)
        {
            switch (propName)
            {
                case "Name":
                    return ToStr(value);
                case "Ozone":
                    return ToIntNullable(value);
                case "SolarR":
                    return ToDoubleNullable(value);
                case "Wind":
                    return ToDouble(value);
                case "Temp":
                    return ToDouble(value);
                case "Month":
                    return ToInt(value);
                case "Day":
                    return ToInt(value);
                default:
                    throw new NotImplementedException();
            }
        }

        private static string ToStr(string value)
        {
            if (value.Equals("NA")) return null;
            else return value;
        }

        private static int? ToIntNullable(string value)
        {
            if (value.Equals("NA")) return null;
            else return System.Convert.ToInt32(value);
        }

        private static double? ToDoubleNullable(string value)
        {
            if (value.Equals("NA")) return null;
            else return System.Convert.ToDouble(value.Replace('.', ','));
        }

        private static int ToInt(string value)
        {
            if (value.Equals("NA")) throw new ArgumentException();
            else return System.Convert.ToInt32(value);
        }

        private static double ToDouble(string value)
        {
            if (value.Equals("NA")) throw new ArgumentException();
            else return System.Convert.ToDouble(value.Replace('.',','));
        }
    }
}