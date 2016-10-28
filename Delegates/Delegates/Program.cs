using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelDataTable modelTable = new ModelDataTable();

            modelTable.InsertRow(0);
            modelTable.InsertColumn(0);

            ViewDataTable viewTable = new ViewDataTable();

            modelTable.RegisterObserver(viewTable);
            modelTable.Put(0, 0, 3);

            modelTable.InsertColumn(1);
            modelTable.Put(0, 1, 4);

            int a = modelTable.Get(0, 1);

            modelTable.RegisterObserver(viewTable);
        }
    }
}
