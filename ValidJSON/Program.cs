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
        public static bool IsValidJsonString(string input)
        {
            return input.Length >= 2 && (IsBetweenQuotes(input) && ValidChar(input));
        }
        private static bool ValidChar(string json)
        {
            int i, count = 0;
            for (i = 0; i < json.Length; i++)
            {
                if (!IsNotAllowedChar(json[i])) count += 1;
                if (GetValueBetweenQuotes(json, i)) continue;
                if (EscapeSequence(json, i)) count += 1;
                else if (EscapeSequenceU(json, i))
                {
                    count += 1;
                    i += 4;
                }
            }
            return count == json.Length;
        }
        private static bool IsBetweenQuotes(string json) => json[0] == '"' && json[json.Length - 1] == '"';
        private static bool IsNotAllowedChar(char c) => (c >= 0d && c < 32d);
        private static bool GetValueBetweenQuotes(string json, int i) => i == 0 || i >= json.Length - 1;
        private static bool EscapeSequenceU(string json, int i) => json[i] == 'u' && i + 4 < json.Length;
        private static bool EscapeSequence(string json, int i)
        {
            return json[i] == '\"'|| json[i] == '\\'|| json[i] == '/'|| json[i] == '\b'
                || json[i] == '\f'|| json[i] == '\n'|| json[i] == '\r'|| json[i] == '\t';
        }

    }
}