public class ErrorHandler
{
    public int ReadInt(int amountChars)
    {
        while (true)
        {
            string inputString = Console.ReadLine().Trim();
            int input;

            if (inputString.Length != amountChars)
            {
                continue;
            }

            try
            {
                input = int.Parse(inputString);
                return input;
            }
            catch
            { }

        }
    }
}