namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }

        public decimal Balance { get
            {
                decimal balance = 0;
                foreach (var transaction in allTransactions)
                {
                    balance += transaction.Amount;
                    
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount), "Amount must be positive");
            }
            Transaction depositTransaction = new Transaction(amount, date, note);
            allTransactions.Add(depositTransaction);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount), "Amount must be positive");
            }

            if(Balance - amount < 0)
            {
                throw new InvalidOperationException( "You do not have sufficient funds to make this transaction");
            }

            Transaction withdrwalTransaction = new Transaction(-amount, date, note);
            allTransactions.Add(withdrwalTransaction);
        }

        public BankAccount(string name)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            MakeDeposit(10000, DateTime.Now, "Kendra");


        }
    }
}
