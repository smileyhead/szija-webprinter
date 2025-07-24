using System.Diagnostics;
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
            string imagesPath = "output/images/";
            string jsonString = File.ReadAllText(jsonPath);
            RootStrings data = JsonSerializer.Deserialize<RootStrings>(jsonString);


            Console.WriteLine("Determining new thumbnails...");
            string[] thumbnailsAll = Directory.GetFiles(imagesPath, "*.png");
            List<string> thumbnailsFiltered = new();

            foreach (string thumbnail in thumbnailsAll) if (!File.Exists($"{thumbnail.Remove(thumbnail.Length - 4)}-small.jpg")) thumbnailsFiltered.Add(thumbnail);
            Console.WriteLine($"Found {thumbnailsFiltered.Count} new of {thumbnailsAll.Length} thumbnails total.");

            if (thumbnailsFiltered.Count > 0)
            {
                Console.WriteLine("Resizing images...");
                DirectoryInfo tempDirectory = Directory.CreateTempSubdirectory("wbprntr-");
                DirectoryInfo tempDirectoryFull = Directory.CreateDirectory($"{tempDirectory.FullName}{Path.DirectorySeparatorChar}{imagesPath}".Replace('/', Path.DirectorySeparatorChar));

                foreach (string thumbnail in thumbnailsFiltered) File.Copy(thumbnail, $"{tempDirectory.FullName}{Path.DirectorySeparatorChar}{thumbnail}");
                var imageMagickProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/C magick mogrify -resize 176x -format jpg -quality 92 *.png",
                        WorkingDirectory = tempDirectoryFull.FullName
                    }
                };
                imageMagickProcess.Start();
                imageMagickProcess.WaitForExit();

                string[] thumbnailsConverted = Directory.GetFiles(tempDirectoryFull.FullName, "*.jpg");
                foreach (string thumbnail in thumbnailsConverted) File.Move(thumbnail, thumbnail.Insert(thumbnail.LastIndexOf('.'), "-small"));
                thumbnailsConverted = Directory.GetFiles(tempDirectoryFull.FullName, "*.jpg");
                foreach (string thumbnail in thumbnailsConverted) File.Move(thumbnail, $"{imagesPath}{Path.DirectorySeparatorChar}{thumbnail.Substring(thumbnail.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
                tempDirectory.Delete(true);
            }


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
