using System;

namespace ValidJSON
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string console = Console.ReadLine();            
            char[] jsonString = console.ToCharArray();
            var result = IsValidJSONString(jsonString);
            if (result == true)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
            Console.ReadLine();
        }

        public static bool IsValidJSONString(char[] jsonString)
        {
            throw new NotImplementedException();
        }
    }
}