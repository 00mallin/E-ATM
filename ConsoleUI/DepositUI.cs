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

            Console.Write("Select account: ");
            int num = Int32.Parse(Console.ReadLine());

            if (num <= 0 || num > userAccounts.Count)
            {
                Console.WriteLine("Invalid selection. Press any key to try again.");
                Console.ReadKey();
                continue;
            }

            Account selectedAccount = userAccounts[num - 1];


            Console.Clear();
            Console.WriteLine("You have: " + selectedAccount.Balance + " kr in your account.");

            Console.Write("Input the amount you would like to insert: ");
            float input = float.Parse(Console.ReadLine());
            Console.Clear();

            selectedAccount.Deposit(input);

            Console.WriteLine($"Success! Your account balance: {selectedAccount.Balance} kr");
            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
            break;
        }
    }

}