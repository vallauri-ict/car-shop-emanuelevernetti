using System;
using System.IO;
using System.Threading;

namespace ConsoleAppProject
{
    public class Utils
    {
        internal static void cancellaFiles()
        {
            DirectoryInfo di = new DirectoryInfo($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\WindowsFormsAppProject\\bin\\Debug\\img");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name != "NoImage.jpg")
                {
                    file.Delete();
                }
            }
            Console.WriteLine("\nFiles eliminati correttamente");
            Thread.Sleep(3000);
        }
    }
}
