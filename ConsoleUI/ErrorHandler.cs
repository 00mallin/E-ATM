public class ErrorHandler
{
    public static string ReadInt(string prompt, int amountChars)
    {
        while (true)
        {
            Console.Write(prompt);
            string inputString = Console.ReadLine().Trim();
            int input;

            if (inputString.Length != amountChars)
            {
                continue;
            }

            try
            {
                foreach (Char c in inputString)
                {
                    input = Convert.ToInt32(c);
                }

                return inputString;
            }
            catch{ }
        }
    }
}