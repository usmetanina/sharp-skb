using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class ModelDataTable : IObservable
    {
        private List<List<int>> dataTable;
        private List<IObserver> observers;

        public ModelDataTable()
        {
            observers = new List<IObserver>();
            dataTable = new List<List<int>>();
        }
        public void Put(int row, int column, int value)
        {
            if (row < 0 || row >= dataTable.Count())
                throw new ArgumentException("Incorrect row");

            if (column < 0 || column >= dataTable[row].Count())
                throw new ArgumentException("Incorrect column");

            dataTable[row][column] = value;
            NotifyObservers();
        }

        public void InsertRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex > dataTable.Count())
                throw new ArgumentException("Incorrect row");

            dataTable.Insert(rowIndex, new List<int>());

            NotifyObservers();
        }

        public void InsertColumn(int columnIndex)
        {
            for (int i = 0; i < dataTable.Count; i++)
            {
                if (columnIndex > dataTable[i].Count())
                    throw new ArgumentException("Incorrect column");

                dataTable[i].Insert(columnIndex, default(int));
            }

            NotifyObservers();
        }

        public int Get(int row, int column)
        {
            if (row < 0 || row >= dataTable.Count())
                throw new ArgumentException("Incorrect row");

            if (column < 0 || column >= dataTable[row].Count())
                throw new ArgumentException("Incorrect column");

            return dataTable[row][column];
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }
}

