using Logic;

public class WithdrawUI
{
    public static void Show(Card card)
    {
        Console.Clear();

        Database db = new();

        Account selectedAccount = db.GetAccount(card.AccountID);

        Console.WriteLine("You have: " + selectedAccount.Balance + " kr in your account.");

        Console.Write("Input the amount you would like to withdraw: ");
        float input = float.Parse(Console.ReadLine());

        selectedAccount.Withdraw(input);

        selectedAccount.ToString();

    }

}