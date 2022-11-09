public class User
{
    // List<BankAccount> accounts = new();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int PersonNumber { get; set; }

    public User(string firstName, string lastName, string address, string phoneNumber, int personNumber)
    {
        // new List<BankAccount>();
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        PersonNumber = personNumber;
    }



}