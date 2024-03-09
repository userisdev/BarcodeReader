using ZXing;
using ZXing.Common;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Drawing;

namespace BarcodeReaderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new BarcodeReader 
            {
                AutoRotate = true,
                Options = new DecodingOptions
                {
                    TryInverted = true,
                    TryHarder = true,
                    PossibleFormats = new[] {BarcodeFormat.EAN_13 }
                }
            };

            using (var bmp = Image.FromFile(args.FirstOrDefault()) as Bitmap)
            {
                var result = reader.Decode(bmp);

                if(result is null)
                {
                    Console.WriteLine("error.");
                }
                else
                {
                    var format = result.BarcodeFormat.ToString();
                    var data = result.Text;
                    Console.WriteLine($"Format:{format}");
                    Console.WriteLine($"Data  :{data}");
                }
            }

            Console.WriteLine("press any key to exit . . .");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
