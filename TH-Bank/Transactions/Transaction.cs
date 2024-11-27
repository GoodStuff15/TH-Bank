

namespace TH_Bank
{
    public class Transaction
    {
        private decimal _amount;
        private int _fromAccount;
        private int _toAccount;
        private DateTime _transferDate;

        public decimal Amount { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public DateTime TransferDate { get; set; }
        public string Id { get; set; }

        public Transaction(decimal amount, Account fromAccount, Account toAccount, string id)
        {
            Amount = amount;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Id = id;
            TransferDate = DateTime.Now;
        }
        public bool TransferFunds() //Method for moneytransfer
        {
            if (FromAccount.Balance >= Amount)
            {                
                FromAccount.Balance -= Amount;
                ToAccount.Balance += Amount;
                return true;                                
            }
            else
            {
                Console.WriteLine("Transfer not complete. Check account balance");
                return false;
            }
        }

        public void MakeTransaction(List<Account> accounts)
        {
            //Display all avalible accounts or option to enter new accountnumber
            Console.WriteLine("Välj ett konto att föra över pengar ifrån: ");
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}, Konto: {accounts[i].AccountNumber} Saldo: {accounts[i].Balance}");
            }
            int fromacc = Int32.Parse(Console.ReadLine()) - 1;
            //Display igen?
            Console.WriteLine("Välj ett konto att föra över pengar till: ");
            //for (int i = 0; i < accounts.Count; i++)
            //{
            //    Console.WriteLine($"{i + 1}, Konto: {accounts[i].AccountNumber} Saldo: {accounts[i].Balance}");
            //}
            int toacc = Int32.Parse(Console.ReadLine()) - 1;

            Account FromAccount = accounts[fromacc];
            Account ToAccount = accounts[toacc];

            Console.WriteLine("Ange beloppet du vill föra över: ");
            decimal Amount = decimal.Parse(Console.ReadLine()); // IMPLEMENTERA FELHANTERING**

            //var transaction = new TransactionFactory().CreateTransaction(Amount, FromAccount, ToAccount, Id);
            //transaction.TransferFunds();
        }
        public override string ToString()
        {
            return $"{TransferDate}|{Amount}|{FromAccount.AccountNumber}|{ToAccount.AccountNumber}";
            //Add "Id" to ToString. Figure out a way to make this unique
        }
        

    }
}
