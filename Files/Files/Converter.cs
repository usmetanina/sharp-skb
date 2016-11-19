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
        public object Convert(Type type, string str)
        {

            if (type == typeof(int))
                return int.Parse(str);

            else if (type == typeof(int?))
            {
                int value;
                if (int.TryParse(str, out value))
                    return value;
                else
                    return null;
            }
            else if (type == typeof(double))
                return double.Parse(str);

            else if (type == typeof(double?))
            {
                double value;
                if (double.TryParse(str, out value))
                    return value;
                else
                    return null;
            }

            else if (type == null)
            {
                if (str == "NA")
                    return null;

                int integerValue;
                if (int.TryParse(str, out integerValue))
                    return integerValue;

                double doubleValue;
                if (double.TryParse(str, out doubleValue))
                    return doubleValue;
                return str;

            }
            return str;
        }
    }
}