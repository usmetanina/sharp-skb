using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Files
{
    class Reader
    {
        public static IEnumerable<string[]> ReadCsv1(string file)
        {
            using (StreamReader stream = new StreamReader(file))
                while (true)
                {
                    var currentString = stream.ReadLine();
                    if (currentString == null)
                    {
                        stream.Close();
                        yield break;
                    }
                    var line = currentString.Split(',');

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == "NA")
                            line[i] = null;
                    }
                    yield return line;
                }
        }


        public static IEnumerable<T> ReadCsv2<T>(string file) where T : new()
        {
            Converter converter = new Converter();
            var allInfoOfProperties = typeof(T).GetProperties();
            
            using (var stream = new StreamReader(file))
            {
                var fields = stream.ReadLine().Replace("\"", "").Split(',');
                while (true)
                {
                    var line = stream.ReadLine();
                    if (line == null)
                        yield break;

                    var newObject = new T();
                    for (var i = 0; i < fields.Length; i++)
                    {
                        var infoOfProp = allInfoOfProperties.First(x => x.Name == fields[i]);
                        var convertedValue = converter.Convert(infoOfProp.Name, line.Split(',')[i]);
                        infoOfProp.SetValue(newObject, convertedValue);
                    }

                    yield return newObject;
                }
            }
        }
    }
}
