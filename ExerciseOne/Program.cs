using System;

namespace ExerciseOne
{
    class Program
    {
        // removeCharacterFromString
        static void Main(string[] args)
        {
            Console.WriteLine("RemoveCharacterFromString exercise");

            char tryAgainChar = 'Y';
            while (tryAgainChar == 'y' || tryAgainChar == 'Y')
            {
                Console.WriteLine();
                Console.Write("Enter a string: ");
                var stringInput = Console.ReadLine();

                Console.Write("Enter the character to remove: ");
                var charInput = Console.ReadKey().KeyChar;

                Console.WriteLine();
                Console.WriteLine($"New string: {RemoveCharacterFromString(stringInput, charInput)}");

                Console.WriteLine();
                Console.WriteLine("Try again? (Y/y = Yes | Press any other key to quit)");
                tryAgainChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static string RemoveCharacterFromString(string input, char toRemove)
        {
            string returnValue = string.Empty;
            if(input == null)
            {
                return null;
            }
            else if(toRemove == default(char))
            {
                return input;
            }
            else
            {
                foreach(var c in input)
                {
                    if(c != toRemove)
                    {
                        returnValue += c;
                    }
                }
            }

            return returnValue;
        }
    }
}
