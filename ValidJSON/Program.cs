using System;

namespace ValidJSON
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (IsValidJSONString(Console.ReadLine()) == true)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");
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
            
            for (i = start; i < json.Length; i++)
            {
                if (!IsNotAllowedChar(json[i]))
                {
                    numberValue += 1;
                    if (i != 0 && i < json.Length - 1)
                    {
                        if (EscapeSequence(json, i))
                        {
                            numberValue += 1;
                        }
                        else if (json[i] == 'u')
                        {
                            j = UnicodeValue(json, ref numberValue, ref i);
                        }
                    }
                }
            }
            return i;
        }

        private static int UnicodeValue(char[] json, ref int numberValue, ref int i)
        {
            int j = 0;
            Char c;
            if (i + 4 < json.Length)
            {
                for (j = 0; j < 4; j++)
                {
                    c = UnicodeChars(json, i, j);
                }
                numberValue = numberValue + 1;
                i = i + 4;
            }

            return j;
        }

        private static char UnicodeChars(char[] json, int i, int j)
        {
            char c = json[i + j + 1];
            if (CharacterIsNumberCharacterInBase(c, 16d) || c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f')
            {
            }

            return c;
        }

        private static bool EscapeSequence(char[] json, int i)
        {
            return json[i] == '\"'
                || json[i] == '\\'
                || json[i] == '/'
                || json[i] == '\b'
                || json[i] == '\f'
                || json[i] == '\n'
                || json[i] == '\r'
                || json[i] == '\t';
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
        private static bool IsNotAllowedChar(char c)
        {            
            return (c >= 0d && c < 32d);
        }
    }
}