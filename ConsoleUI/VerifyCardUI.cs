using Logic;

public class VerifyCardUI
{
    public static Card Show()
    {
        Database db = new();
        Card card = null;
        int PinTries = 0;

        while (card == null)
        {
            // Gets card number
            Console.Clear();
            string inputCardNumber = ErrorHandler.ReadNumber("Enter your card number: ", 4);


            // Gets and verifies pin input
            if (db.CheckCard(inputCardNumber))
            {
                // If pin code is wrong
                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();

                    string inputPin = ErrorHandler.ReadNumber("Enter your pin code: ", 4);

                    card = db.GetCard(inputCardNumber, inputPin);

                    if (card != null)
                    {
                        // Card is verified;
                        return card;
                    }
                    else
                    {
                        PinTries++;
                    }
                }

                if (PinTries == 3)
                {
                    db.LockCard(inputCardNumber);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Your card is invalid!");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        return null;
    }
}