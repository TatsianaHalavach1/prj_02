using System;
using System.IO;

namespace TaskA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input text or file path:");
            string lineFromConsole = Console.ReadLine();
            if (File.Exists(lineFromConsole))
            {
                lineFromConsole = File.ReadAllText(lineFromConsole);
                //обработка того, что файл для только чтения
            }
            SentenseWorker sworker = SentenseWorker.GetInstanse(lineFromConsole);
            sworker.Do();
            Console.WriteLine(sworker.Text);

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
