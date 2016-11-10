using System;
using System.Diagnostics;

namespace MemoryMenegement
{
    class Timer : IDisposable
    {
        private readonly Stopwatch stopwatch;
        private bool isDisposed = false;

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
            Dispose(true);
        }

        protected virtual void Dispose(bool fromFinalize)
        {
            if (!isDisposed)
            {
                if (!fromFinalize)
                {
                    stopwatch.Stop();
                }
                isDisposed = true;
            }
        }

        ~Timer()
        {
            Dispose(false);
        }
    }
}
