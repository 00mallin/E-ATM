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
                input = int.Parse(inputString);
                return inputString;
            }
            catch{ }
        }
    }
}