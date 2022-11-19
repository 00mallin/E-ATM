using Logic;

internal class Program
{
    static Card card;
    static Database db = new();
    private static void Main(string[] args)
    {
        // Verifies card
        card = VerifyCardUI.Show();

        if (card == null) // Exit if card is invalid
        {
            Console.WriteLine("Too many tries! Your card is locked!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        // Menu
        while (true)
        {
            Console.Clear();

            Console.WriteLine("\t----- Welcome to your local ATM -----");
            Console.WriteLine
            (
            "[D]eposit\n" + // Show DepositUI
            "[W]ithdraw\n" + // Show WithdrawUI
            "[B]alance\n" + // Show BalanceUI
            "[H]istory\n" + // Show HistoryUI
            "[E]xit" // Exit application
            );

            var keypress = Console.ReadKey(true).Key;

            Console.WriteLine("Your choice is: " + keypress.ToString() + "\nPlease wait");
            Thread.Sleep(1500);

            // Handles menu selection
            switch (keypress)
            {
                case ConsoleKey.D:
                    DepositUI.Show(card);
                    break;

                case ConsoleKey.W:
                    WithdrawUI.Show(card);
                    break;

                case ConsoleKey.B:
                    BalanceUI.Show(card);
                    break;

                case ConsoleKey.H:
                    HistoryUI.Show(card);
                    break;

                case ConsoleKey.E:
                    Environment.Exit(0);
                    return;

                default:
                    Console.WriteLine("There is no choice matching your input, please try again");
                    Thread.Sleep(4000);
                    break;
            }
        }
    } //Main
}
