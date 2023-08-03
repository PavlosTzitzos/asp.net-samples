using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1OCRTesseract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Ocr = new IronTesseract(); // nothing to configure
            Ocr.Language = OcrLanguage.English;
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            using (var Input = new OcrInput())
            {
                Console.WriteLine("Start:");
                Input.Add("IMG_20230803_133952_2.jpg");
                //Input.Add("IMG_20230803_133952.jpg");
                //Input.Add("Screenshot_2023-07-04_151737.png");
                var Result = Ocr.Read(Input);
                string ExtractedText = Result.Text;
                Console.WriteLine(ExtractedText);
                Console.WriteLine("Finished...\n");
                Console.ReadLine();
            }
            
        }
    }
}
