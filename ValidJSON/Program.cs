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
        public static bool IsValidJsonString(string input) => IsBetweenQuotes(input) && ValidString(input);

        private static bool ValidString(string json)
        {
            int i,index = 0;
            for (i = 0;i < json.Length;i++)
            {
                if (!IsAllowedChar(json[i]))
                    index += 1;
                if (IsEscapeSequence(json,i))
                    index += 1;
                if (IsUnicodeEscapeSequence(json,i))
                {
                    index += 1;
                    i += 4;
                }
            }

            return index == json.Length;
        }

        private static bool IsBetweenQuotes(string json) => json.Length >= 2 && json[0] == '"' && json[json.Length - 1] == '"';

        private static bool IsAllowedChar(char c) => c >= 0d && c < 32d ;

        private static bool IsUnicodeEscapeSequence(string json, int i) => json[i] == 'u' && i + 4 < json.Length;

        private static bool IsEscapeSequence(string json, int i) => i != 0 && i != json.Length - 1
                                                                           && "\"\\".Contains(json[i])
                                                                    || json[i] == '\\' &&
                                                                    "/bfnrt\"\\".Contains(json[i + 1]);
    }
}
