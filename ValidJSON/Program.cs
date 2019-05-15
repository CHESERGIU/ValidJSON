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
            int i;                      
            int start = 0; 
            int numberValue = 0;
            if (json[(int)(0)] == '"' && json[(int)(json.Length - 1)] == '"')
            {
                for (i = start; i < json.Length; i++)
                {
                    if (!IsJSONChar(json[(int)(i)]))
                    {
                        numberValue += 1;                        
                    }
                }
                if(numberValue == json.Length)
                    return true;
            }
            return false;
        }

        private static bool IsJSONChar(char v)
        {
            int cnr;
            bool isValid;
            cnr = v;
            if (cnr >= 0d && cnr < 32d)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
    }
}