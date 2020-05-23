using System;
using System.IO;

namespace ExerciseTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SumIntegersInFile exercise");

            char tryAgainChar = 'Y';
            while (tryAgainChar == 'y' || tryAgainChar == 'Y')
            {
                Console.WriteLine();
                Console.Write("Enter a valid file path: ");
                var filePathInput = Console.ReadLine();

                if (string.IsNullOrEmpty(filePathInput) || !File.Exists(filePathInput))
                {
                    Console.WriteLine("Invalid file path");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Sum of integers in file: {SumIntegersInFile(filePathInput)}");
                }                

                Console.WriteLine();
                Console.WriteLine("Try again? (Y/y = Yes | Press any other key to quit)");
                tryAgainChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static int SumIntegersInFile(string fullFilePath) 
        {
            // NOTE: this is already being checked above, but if this is not a simple console app, uncomment the codes below

            //if (string.IsNullOrEmpty(fullFilePath))
            //{
            //    return 0;
            //}
            //else if (!File.Exists(fullFilePath))
            //{
            //    return 0;
            //}
            //else
            //{
                string[] lines = File.ReadAllLines(fullFilePath);
                int sum = 0;
                int addend = 0;
                foreach(var line in lines)
                {
                    if(int.TryParse(line, out addend))
                    {
                        sum += addend;
                    }
                }

                return sum;
            //}
        }
    }
}
