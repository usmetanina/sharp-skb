using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryMenegement
{
    class Timer:  IDisposable
    {
        private readonly Stopwatch stopwatch;
        public long ElapsedMilliseconds
        {
            get
            {
                return stopwatch.ElapsedMilliseconds;
            }
        }

        public Timer()
         {
            stopwatch = new Stopwatch();
        }

        public Timer Start()
        {
            stopwatch.Start();
            return this;
        }

        public Timer Continue()
        {
            stopwatch.Start();
            return this;
        }

        public void Dispose()
        {
            stopwatch.Stop();
        }
    }
}
