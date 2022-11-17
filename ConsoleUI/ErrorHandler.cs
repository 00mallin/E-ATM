public class ErrorHandler
{
    /// <summary>
    /// Checks if input is a number
    /// </summary>
    /// <param name="prompt">Prompt message to user</param>
    /// <param name="amountChars">-1 = unspecified amount</param>
    /// <returns></returns>
    public static string ReadNumber(string prompt, int amountChars)
    {
        while (true)
        {
            Console.Write(prompt);
            string inputString = Console.ReadLine().Trim();

            if ((inputString.Length != amountChars && amountChars != -1) || string.IsNullOrWhiteSpace(inputString))
            {
                continue;
            }

            // Check if the string only contains integers
            bool onlyInts = true;

            foreach (char c in inputString)
            {
                if(!Char.IsDigit(c))
                {
                    onlyInts = false;
                    break;
                }
            }

            if(onlyInts)
            {
                return inputString;
            }
        }
    }

    public static float ReadFloat(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string inputString = Console.ReadLine().Trim();
            float input;

            if (string.IsNullOrWhiteSpace(inputString))
            {
                continue;
            }

            // Check if it's a float first
            try
            {
                input = float.Parse(inputString);
                return input;
            }
            catch { }
        }
    }
}