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
            int i, j;
            Char c;
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
                        else if (json[(int)(i)] == 'u')
                        {
                            if (i + 4 < json.Length)
                            {
                                for (j = 0; j < 4; j = j + 1)
                                {
                                    c = json[(int)(i + j + 1)];
                                    if (CharacterIsNumberCharacterInBase(c, 16d) || c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f')
                                    {
                                    }                                    
                                }
                                numberValue = numberValue + 1;
                                i = i + 4;
                            }                            
                        }
                    }
                }                
            }
            return i;
        }

        private static bool CharacterIsNumberCharacterInBase(char c, double v)
        {
            char[] numberTable;
            double i;
            bool found;

            numberTable = GetDigitCharacterTable();
            found = false;

            for (i = 0d; i < v; i = i + 1d)
            {
                if (numberTable[(int)(i)] == c)
                {
                    found = true;
                }
            }

            return found;
        }
        public static char[] GetDigitCharacterTable()
        {
            char[] numberTable;

            numberTable = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            return numberTable;
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