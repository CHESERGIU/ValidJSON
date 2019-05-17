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
                i = ValidChar(json, start, ref numberValue);
                if (numberValue == json.Length)
                    return true;                
            }
            return false;
        }

        private static int ValidChar(char[] json, int start, ref int numberValue)
        {
            int i;
            for (i = start; i < json.Length; i++)
            {
                if (!IsNotAllowedChar(json[(int)(i)]))
                {
                    numberValue += 1;
                    if (i != 0 && i < json.Length - 1)
                    {
                        if (json[(int)(i)] == '\"'
                            || json[(int)(i)] == '\\'
                            || json[(int)(i)] == '/'
                            || json[(int)(i)] == '\b'
                            || json[(int)(i)] == '\f'
                            || json[(int)(i)] == '\n'
                            || json[(int)(i)] == '\r'
                            || json[(int)(i)] == '\t')
                        {
                            numberValue += 1; 
                        }
                    }
                }                
            }
            return i;
        }

        private static bool IsNotAllowedChar(char v)
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