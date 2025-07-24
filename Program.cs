using System.Text.Json;

namespace Szija_Website_Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialising...");
            string jsonPath = "template/data.json";
            string inputPath = "template/";
            string outputPath = "output/";
            string jsonString = File.ReadAllText(jsonPath);
            RootStrings data = JsonSerializer.Deserialize<RootStrings>(jsonString);



            Printer huPrinter = new("hu", data);
            Printer enPrinter = new("en", data);

            Console.Write("Compiling pages... 0/4");
            huPrinter.PrintAll(outputPath);
            Console.Write("\rCompiling pages... 2/4");
            enPrinter.PrintAll(outputPath);
            Console.WriteLine("\rCompiling pages... 4/4");
            Console.WriteLine("Finished.");
        }
    }
}
