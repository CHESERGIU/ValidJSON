using System;

namespace ValidJSON
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string console = Console.ReadLine();
            var result = IsValidJSONString(console);
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

        public static bool IsValidJSONString(string console)
        {
            char[] json = console.ToCharArray();
            bool success, done;
            double i;          
            success = true;
            done = false;
            double start = 0;            
            
            for (i = start + 1d; i < json.Length && !done && success; i = i + 1d)
            {
                if (json[(int)(0)] == '"' && json[(int)(json.Length - 1)] == '"')
                {
                    return true;
                }
            }
            return false;
        }
    }
}