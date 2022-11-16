using dapper;
using Logic;

public class ErrorHandler
{
    public int ReadInt(int amountChars)
    {
        while (true)
        {
            string inputString = Console.ReadLine();
            int input;

            try
            {
                input = int.Parse(inputString);
                return input;
            }
            catch { }            
        }
    }
}