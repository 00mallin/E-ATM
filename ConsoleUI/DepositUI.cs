using Logic;

public class DepositUI 
{
    public static void Show()
    {
        Console.Clear();
        Database db = new();
        Card card = new();
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

}