using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MemoryMenegement
{
    class BitmapEditor : IDisposable
    {
        private readonly Bitmap bitmap;
        private readonly BitmapData bitmapData;

        private bool isDisposed = false;

        public BitmapEditor(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        }

        public void SetPixel(int x, int y, byte red, byte green, byte blue)
        {
            int offset = 3 * x + y * bitmapData.Stride;
            Marshal.Copy(new[] { blue, green, red }, 0, IntPtr.Add(bitmapData.Scan0, offset), 3);
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
                    bitmap.UnlockBits(bitmapData);
                }
                isDisposed = true;
            }
        }

        ~BitmapEditor()
        {
            Dispose(false);
        }
    }
}