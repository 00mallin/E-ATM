using Logic;

public class DepositUI 
{
    public static void Show(Card card)
    {
        Database db = new();
        List<Account> userAccounts = db.GetUserAccounts(card.UserID);

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < userAccounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userAccounts[i]}");
            }

            int num = int.Parse(ErrorHandler.ReadNumber("Select account: ", -1));

            if (num <= 0 || num > userAccounts.Count)
            {
                Console.Write("Invalid selection. Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            Account selectedAccount = userAccounts[num - 1];


            Console.Clear();
            Console.WriteLine("You have: " + selectedAccount.Balance + " kr in your account.");

            float input = ErrorHandler.ReadFloat("Deposit amount: ");
            Console.Clear();

            selectedAccount.Deposit(input);

            Console.WriteLine($"Success! Your account balance: {selectedAccount.Balance} kr");
            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
            break;
        }
    }

}