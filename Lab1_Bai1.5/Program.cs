using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Input folder path:");
        string? folderPath = Convert.ToString(Console.ReadLine());

        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath);

            if (files.Length > 0)
            {
                Console.WriteLine("List of files in directory:");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("The directory does not contain files.");
            }
        }
        else
        {
            Console.WriteLine("Directory path does not exist.");
        }
    }
}
