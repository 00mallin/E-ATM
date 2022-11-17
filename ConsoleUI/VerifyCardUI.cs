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
            Console.WriteLine("Enter your card number: ");
            string inputCardNumber = Console.ReadLine();


            // Gets and verifies pin input
            if (db.CheckCard(inputCardNumber))
            {
                // If pin code is wrong
                for (int i = 0; i < 3; i++)
                {
                    Console.Clear();

                    Console.WriteLine("Enter your pin code");
                    string inputPin = Console.ReadLine();

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
        }

        return null;
    }
}