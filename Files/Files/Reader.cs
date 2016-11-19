using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace Files
{
    class Reader
    {
        private static IEnumerable<string[]> ReadCsv(string file)
        {
            using (StreamReader stream = new StreamReader(file))
                while (true)
                {
                    var currentString = stream.ReadLine();
                    if (currentString == null)
                        break;
                    var line = currentString.Split(',');

                    yield return line;
                }
        }

        public static IEnumerable<string[]> ReadCsv1(string file)
        {
            foreach (var line in ReadCsv(file))
            {
                for (int i = 0; i < line.Length; i++)
                    if (line[i] == "NA")
                        line[i] = null;

                yield return line;
            }
        }


        public static IEnumerable<T> ReadCsv2<T>(string file) where T : new()
        {
            Converter converter = new Converter();
            var allInfoOfProperties = typeof(T).GetProperties();
            string[] fields = null;
            foreach (var line in ReadCsv(file))
            {
                if (fields == null)
                    fields = line;
                else
                {
                    var newObject = new T();
                    for (var i = 0; i < line.Length; i++)
                    {
                        var infoOfProperty = allInfoOfProperties.First(select => select.Name == fields[i].Replace("\"",""));
                        var value = converter.Convert(infoOfProperty.PropertyType, line[i].Replace(".", ","));
                        infoOfProperty.SetValue(newObject, value);
                    }

                    yield return newObject;
                }
            }
        }

        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string file)
        {
            Converter converter = new Converter();
            Type[] types = new Type[] { typeof(double), typeof(int), typeof(string) };
            string[] fields = null;

            foreach (var line in ReadCsv(file))
            {
                if (fields == null)
                    fields = line;
                else
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    for (var i = 0; i < fields.Length; i++)
                        result.Add(fields[i].Replace("\"", ""), converter.Convert(null,line[i].Replace(".", ",")));

                    yield return result;
                }
            }
        }


        public static IEnumerable<dynamic> ReadCsv4(string file)
        {
            Converter converter = new Converter();
            string[] fields = null;

            foreach (var line in ReadCsv(file))
            {
                if (fields == null)
                    fields = line;
                else
                { 
                    IDictionary<string, object> dynamicDictionary = null;
                    var expandoObject = new ExpandoObject();
                    dynamicDictionary = expandoObject;

                    for (var i = 0; i < line.Length; i++)
                        dynamicDictionary.Add(fields[i].Replace("\"", ""), converter.Convert(null,line[i].Replace(".",",")));

                    yield return dynamicDictionary;
                }
            }
        }
    }
}
