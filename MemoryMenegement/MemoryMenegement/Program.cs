using System;
using System.Threading;
using System.Drawing;

namespace MemoryMenegement
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            using (timer.Start())
            {
                Thread.Sleep(150);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            var value = 678+789;
            Console.WriteLine("тянем время");

            using (timer.Continue())
            {
                Thread.Sleep(250);
            }
            Console.WriteLine(timer.ElapsedMilliseconds); //400

            var bitmap = (Bitmap)Bitmap.FromFile("img.jpg");

            Timer timerForStandartSet = new Timer();
            using (timerForStandartSet.Start())
            {
                for (int i = 0; i < bitmap.Width; i++)
                    for (int j = 0; j < bitmap.Height; j++)
                        bitmap.SetPixel(i, j, Color.White);
            }
            Console.WriteLine(timerForStandartSet.ElapsedMilliseconds);

            Timer timerForMySet = new Timer();
            using (timerForMySet.Start())
            {
                using (var bitmapEditor = new BitmapEditor(bitmap))
                {
                    for (var i = 0; i < bitmap.Width; i++)
                        for (var j = 0; j < bitmap.Height; j++)
                            bitmapEditor.SetPixel(i, j, 255, 255, 255);
                }
            }
            Console.WriteLine(timerForMySet.ElapsedMilliseconds);
        }
    }
}
