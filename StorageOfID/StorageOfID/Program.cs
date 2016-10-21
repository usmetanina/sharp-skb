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
            storage.Create<MyType>();
            storage.Create<MyType>();

            var b = storage.GetPairsByType<MyType>();
           
            b.Add(Guid.NewGuid(), 5);
            b.Clear();

            b = storage.GetPairsByType<MyType>();
        }
    }
}
