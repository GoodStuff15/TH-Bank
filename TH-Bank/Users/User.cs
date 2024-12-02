namespace TH_Bank
{
    public abstract class User
    {
        private string _id;
        private string _passWord;


        public string Id { get; set; }
        public string PassWord { get; set; }
        public abstract string UserType { get; }
        public bool IsLoggedIn { get; set; }
        public string UserName { get; set; }

        public bool IsBlocked { get; set; }

        //public decimal LoanLimit { get; set; }
        public User(string id, string userName, string passWord)
        {
            Id = id;
            PassWord = passWord;
            IsLoggedIn = false;
            UserName = userName;
        }

        public abstract string ToString();

        //private decimal SetMaxLoan()
        //{
        //    User current = ActiveUserSingleton.GetInstance();

        //    var activeUser = new AccountDataHandler();

        //    decimal maxLoan = 0;

        //    List<Account> accounts = activeUser.LoadAll(current.Id);
        //    foreach (var acc in accounts)
        //    {
        //        maxLoan +=acc.Balance;
        //    }
        //    decimal maxLoanAmount = maxLoan * 5;

        //    current.LoanLimit = maxLoanAmount;

        //    return maxLoanAmount;
        //}
    }
}
