using Logic;

internal class Program
{
    static Account account;
    static Card card;
    static Database db = new();
    private static void Main(string[] args)
    {
        card = VerifyCardUI.Show();

        if (card == null)
        {
            Console.WriteLine("Card couldn't be verified!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        while (true)
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

            Console.WriteLine("Your choice is: " + keypress.ToString() + "\nPlease wait");
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
                    Balance();
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

        List<Account> userAccounts = db.GetUserAccounts(card.UserID);

        for (int i = 0; i < userAccounts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {userAccounts[i]}");
        }

        Console.Write("Select account: ");
        int num = Int32.Parse(Console.ReadLine());

        if (num >= 0 && num > userAccounts.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Account selectedAccount = userAccounts[num - 1];

        Console.WriteLine("You have: " + selectedAccount.Balance + " kr in your account.");

        Console.Write("Input the amount you would like to insert: ");
        float input = float.Parse(Console.ReadLine());

        selectedAccount.Deposit(input);

        selectedAccount.ToString();

    }

    static void WithdrawMoney()
    {
        Console.Clear();

        Account selectedAccount = db.GetAccount(card.AccountID);

        Console.WriteLine("You have: " + selectedAccount.Balance + " kr in your account.");

        Console.Write("Input the amount you would like to withdraw: ");
        float input = float.Parse(Console.ReadLine());

        selectedAccount.Withdraw(input);

        selectedAccount.ToString();
    }

    static void Balance()
    {
        Console.Clear();

        List<Account> userAccounts = db.GetUserAccounts(card.UserID);

        for (int i = 0; i < userAccounts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {userAccounts[i]}");
        }
        
        while (true)
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.Enter)
            {
                break;
            }
        }
    }
}
