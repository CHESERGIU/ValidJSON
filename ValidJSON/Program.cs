using System;

namespace ValidJSON
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsValidJsonString(Console.ReadLine()) == true ? "Valid" : "Invalid");
            Console.ReadLine();
        }

        public static bool IsValidJsonString(string console)
        {
            var json = console.ToCharArray();  
            var numberValue = 0;
            if (json[(int) 0] != '"' || json[(int) (json.Length - 1)] != '"') return false;
            var i = ValidChar(json, ref numberValue);
            return numberValue == json.Length;
        }

        private static int ValidChar(char[] json, ref int numberValue)
        {
            int i, j;
            const int start = 0;
            for (i = start; i < json.Length; i++)
            {
                if (IsNotAllowedChar(json[i])) continue;
                numberValue += 1;
                if (i == 0 || i >= json.Length - 1) continue;
                if (EscapeSequence(json, i))
                    numberValue += 1;
                else if (json[i] == 'u') j = UnicodeValue(json, ref numberValue, ref i);
            }
            return i;
        }

        private static int UnicodeValue(char[] json, ref int numberValue, ref int i)
        {
            var j = 0;
            char c;
            if (i + 4 >= json.Length) return j;
            for (j = 0; j < 4; j++) c = UnicodeChars(json, i, j);
            numberValue += 1;
            i += 4;

            return j;
        }

        private static char UnicodeChars(char[] json, int i, int j)
        {
            var c = json[i + j + 1];
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
            double i;

            var numberTable = GetDigitCharacterTable();
            var found = false;

            for (i = 0d; i < v; i += 1d)
                if (numberTable[(int) i] == c)
                    found = true;

            return found;
        }
        public static char[] GetDigitCharacterTable()
        {
            var numberTable = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            return numberTable;
        }
        private static bool IsNotAllowedChar(char c)
        {            
            return (c >= 0d && c < 32d);
        }
    }
}