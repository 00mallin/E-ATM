using Logic;

internal class Program
{
    static Account account;
    static Card card;
    static Database db = new();
    private static void Main(string[] args)
    {
        card = VerifyCardUI.Show();

        if (card == null) // Exit if card is invalid
        {
            Console.WriteLine("Card couldn't be verified!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        // Menu
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
                    DepositUI.Show(card);
                    break;

                case ConsoleKey.W:
                    WithdrawUI.Show(card);
                    break;

                case ConsoleKey.B:
                    BalanceUI.Show(card);
                    break;

                case ConsoleKey.H:
                    Console.Write("History of your transactions: ");
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    return;

                default:
                    Console.WriteLine("There is no choice matching your input, please try again");
                    break;
            }
        }
    } //Main
}
