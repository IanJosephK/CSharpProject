namespace MySuperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("Kendra");
            Console.WriteLine($"A new account for {bankAccount.Owner} was created, they have ${bankAccount.Balance}");
        }
    }
}