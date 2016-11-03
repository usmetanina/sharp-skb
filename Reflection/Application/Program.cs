using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH_DLL = @"C:\UG\sharp-skb.git\Reflection\Solution";

            foreach (string file in Directory.GetFiles(PATH_DLL))
            {
                Assembly assembly = Assembly.LoadFile(file);

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterface(typeof(IPlugin).FullName) != null && !type.IsInterface)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        Console.WriteLine(plugin.Name);
                    }
                }
            }
        }
    }
}
