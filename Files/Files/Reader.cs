using System;
using System.Collections.Generic;
using System.IO;


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
    }
}
