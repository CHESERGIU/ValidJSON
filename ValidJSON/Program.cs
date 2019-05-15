using System;

namespace ValidJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            string console = Console.ReadLine();
            String errorMessages = null;
            char[] jsonString = console.ToCharArray();
            var result = IsValidJSONString(jsonString, errorMessages);
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
        public static bool IsJSONIllegalControllCharacter(char c)
        {
            double cnr;
            bool isControll;


            cnr = c;

            if (cnr >= 0d && cnr < 32d)
            {
                isControll = true;
            }
            else
            {
                isControll = false;
            }

            return isControll;
        }
        public static bool CharacterIsNumberCharacterInBase(char c, double basex)
        {
            char[] numberTable;
            double i;
            bool found;

            numberTable = GetDigitCharacterTable();
            found = false;

            for (i = 0d; i < basex; i = i + 1d)
            {
                if (numberTable[(int)(i)] == c)
                {
                    found = true;
                }
            }

            return found;
        }
        private static bool IsValidJSONString(char[] json, string errorMessages)
        {            
            bool success, done;
            double i, j;
            char c;


            success = true;
            done = false;
            double start = 0;
            double numberValue = 1d;

            for (i = start + 1d; i < json.Length && !done && success; i = i + 1d)
            {
                if (!IsJSONIllegalControllCharacter(json[(int)(i)]))
                {
                    if (json[(int)(i)] == '\\')
                    {
                        i = i + 1d;
                        if (i < json.Length)
                        {
                            if (json[(int)(i)] == '\"' || json[(int)(i)] == '\\' || json[(int)(i)] == '/' || json[(int)(i)] == 'b' || json[(int)(i)] == 'f' || json[(int)(i)] == 'n' || json[(int)(i)] == 'r' || json[(int)(i)] == 't')
                            {
                                numberValue = numberValue + 1d;
                            }
                            else if (json[(int)(i)] == 'u')
                            {
                                if (i + 4d < json.Length)
                                {
                                    for (j = 0d; j < 4d && success; j = j + 1d)
                                    {
                                        c = json[(int)(i + j + 1d)];
                                        if (CharacterIsNumberCharacterInBase(c, 16d) || c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f')
                                        {
                                        }
                                        else
                                        {
                                            success = false;
                                            errorMessages = "Invalid";
                                        }
                                    }
                                    numberValue = numberValue + 1d;
                                    i = i + 4d;
                                }
                                else
                                {
                                    success = false;
                                    errorMessages = "Invalid";
                                }
                            }
                            else
                            {
                                success = false;
                                errorMessages = "Invalid";
                            }
                        }
                        else
                        {
                            success = false;
                            errorMessages = "Invalid";
                        }
                    }
                    else if (json[(int)(i)] == '\"')
                    {
                        numberValue = numberValue + 1d;
                        done = true;
                    }
                    else
                    {
                        numberValue = numberValue + 1d;
                    }
                }
                else
                {
                    success = false;
                    errorMessages = "Invalid";
                }
            }

            if (done)
            {
                numberValue = i - start;
            }
            else
            {
                success = false;
                errorMessages = "Invalid";
            }

            return success;
        }
        public static char[] GetDigitCharacterTable()
        {
            char[] numberTable;

            numberTable = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            return numberTable;
        }
    }
}
