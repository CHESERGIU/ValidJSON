using System;

namespace ValidJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string console = Console.ReadLine();
            String errorMessages = null;
            char[] jsonString = console.ToCharArray();
            Console.WriteLine(IsValidJSONString(jsonString, errorMessages));
            Console.ReadLine();
        }

        private static bool IsValidJSONString(char[] jsonString, string errorMessages)
        {
            throw new NotImplementedException();
        }
    }
}
