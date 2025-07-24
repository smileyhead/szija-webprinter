using System.Text.Json;

namespace Szija_Website_Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = "template/data.json";
            string inputPath = "template/";
            string outputPath = "output/";
            string jsonString = File.ReadAllText(jsonPath);
            RootStrings data = JsonSerializer.Deserialize<RootStrings>(jsonString);

            for (int i = 0; i < 2; i++)
            {
                Printer huPrinter = new("hu", data);
                Printer enPrinter = new("en", data);

                huPrinter.PrintAll(outputPath);
                enPrinter.PrintAll(outputPath);
            }

            
        }
    }
}
