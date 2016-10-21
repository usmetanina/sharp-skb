using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageOfID
{
    class MyType{}
    class Program
    {
        static void Main(string[] args)
        {
            StorageOfID storage = new StorageOfID();
            var a = storage.Create<MyType>();
        }
    }
}
