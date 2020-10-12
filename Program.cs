using System;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace labb3
{
    class Program
    {
        static void Main(string[] args)
        {
            Image image = null;
            Console.WriteLine("Enter file path: ");
            string filePath = Console.ReadLine();
            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    image = Image.FromStream(fs); ;
                }

                var imageFormat = GetImageFormat(image);
                switch (imageFormat)
                {
                    case Format.Bmp:
                        Console.WriteLine("This is a .bmp image. Resolution is: " + image.Width + "x" + image.Height);
                        break;
                    case Format.Png:
                        Console.WriteLine("This is a .png image. Resolution is: " + image.Width + "x" + image.Height);
                        break;
                    case Format.Unknown:
                        Console.WriteLine("This is not a valid .bmp or .png file!");
                        break;
                    default:
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }

            Console.ReadLine();
        }

        public enum Format
        {
            Bmp,
            Png,
            Unknown
        }

        public static Format GetImageFormat(Image image)
        {
            if (ImageFormat.Png.Equals(image.RawFormat))
                return Format.Png;
            else if (ImageFormat.Bmp.Equals(image.RawFormat))
                return Format.Bmp;
            else
                return Format.Unknown;
        }
    }
}
