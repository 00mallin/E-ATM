using Logic;

internal class Program
{
    static Account account;
    static Card card;
    static Database db = new();
    static int PinTries = 3;

    private static void Main(string[] args)
    {
        while (true)
        {
            // Gets card number
            Console.Clear();
            Console.WriteLine("Enter your card number: ");
            string inputCardNumber = Console.ReadLine();


            // Gets pin code
            if (db.CheckCard(inputCardNumber))
            {
                // If pin code is wrong
                // TODO lås kortet ifall användaren gjort 3 försök,
                // låt annars användaren försöka igen
                for (int i = 0; i < PinTries; i++)
                {
                    Console.WriteLine("Enter your pin code");
                    string inputPin = Console.ReadLine();

                    card = db.GetCard(inputCardNumber, inputPin);

                    if (i == PinTries)
                    {
                        //Låsa kortet 

                        Environment.Exit(1);
                    }
                    else if (card != null)
                    {
                        break;
                    }
                }

            }
            else
            {
                // If the card number doesn't exist
                continue;
            }
        }


        bool running = true;
        while (running)
        {
            Console.Clear();

            Console.WriteLine("\t----- Welcome to your local bank -----");
            Console.WriteLine
            (
            "[I]nsert\n" + // TODO Använd db.GetUserAccounts() för att hämta alla konton
            "[W]ithdraw\n" + // TODO Använd db.GetAccount() för att endast hämta kontot som pengarna ska dras ifrån
            "[B]alance\n" + // TODO Visa alla användarens konton tillsammans med deras saldo
            "[H]istory\n" + // TODO Visa transaktioner för de olika kontona
            "[E]xit" // TODO Ta användaren tillbaka till första sidan för att kunna mata in nytt kort
                     // Eller avsluta applikationen
            );

            var keypress = Console.ReadKey().Key;

            Console.WriteLine("Your chouce is: " + keypress.ToString() + "\nPleas whit");
            Thread.Sleep(2000);

            switch (keypress)
            {
                case ConsoleKey.I:
                    InsertMoney();
                    break;

                case ConsoleKey.W:
                    WithdrawMoney();
                    break;

                case ConsoleKey.B:
                    Console.Write("Your balance is: ");
                    Console.ReadLine();
                    break;

                case ConsoleKey.H:
                    Console.Write("History of your transactions: ");
                    break;

                case ConsoleKey.E:
                    return;

                default:
                    Console.WriteLine("There is no choice matching your input, please try again");
                    break;
            }
        }
    } //Main


    static void InsertMoney()
    {
        Console.Clear();

        Console.Write("Input the amount you would like to insert: ");
        float input = float.Parse(Console.ReadLine());

        account.Deposit(input);

        account.ToString();

    }

    static void WithdrawMoney()
    {
        Console.Clear();

        Console.Write("Input the amount you would like to draw: ");
        float input = float.Parse(Console.ReadLine());

        account.Withdraw(input);

        account.ToString();
    }
}
