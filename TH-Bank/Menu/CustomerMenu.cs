
namespace TH_Bank
{
    public class CustomerMenu : Menu
    {

        public CustomerMenu()
        {
            _menu = new string[] // Menu in array = easy to add options.
            {
                "1. Show balance / accounts.",
                "2. Show transactions.",
                "3. Internal transfer.",
                "4. External transfer.",
                "5. Apply for loan.",
                "6. Logout.",
                "7. Exit program.",
            };
            menuWidth = CalculateWidth(extraWidth: 10);
        }


        public override void ShowMenu()
        {
            DrawBorder();
            foreach (string item in _menu)
            {
                DrawMenuItem(item);
            }
            DrawBorder();
        }


        public void MenuCustomer()
        {
            optionCount = _menu.Length; // Combined with Choice method from MenuClass wrongful inputs can't be made.
            access = true;
            while (access)
            {
                ShowMenu();
                int customerChoice = Choice(optionCount); 
                switch (customerChoice)
                {

                    case 1:
                        //ShowAccounts(); // Shows accounts & balance of current user.
                        break;

                    case 2:
                        //Show transactions.
                        // Logger.
                        break;

                    case 3:
                        // Transfer between accounts.
                        MakeInternalTransaction(ActiveUserSingleton.GetInstance(), new AccountDataHandler());
                        break;

                    case 4:
                        //Transfer between customers.
                        MakeExternalTransaction(ActiveUserSingleton.GetInstance(), new AccountDataHandler());
                        break;

                    case 5:
                        //Set up a new loan.
                        break;

                    case 6:
                        Return(); //Log out.
                        break;

                    case 7:
                        Close(); // Close application.
                        break;
                }
            }
        }
        public override void ShowAccounts(ActiveUserSingleton user, AccountDataHandler activeUser)
        {
            List<Account> accountList = activeUser.LoadAll(user.UserName);

            foreach (var acc in accountList)
            {
                Console.WriteLine(acc.ToString());
            }
        }

        //Lät interna/externa transaktioner vara kvar i två separata metoder. Blev så brötigt med val av transaktionstyp
        //inne i en enda metod. Misstycker ni fullständigt så gör jag om.
        public void MakeInternalTransaction(User user, AccountDataHandler activeUser)
        {
            //ShowAccounts();   Ska det verkligen vara en ActiveUserSingleton som inparameter till ShowAccounts?
            
            List<Account> accountList = activeUser.LoadAll(user.UserName);   //Behöver komma åt listan från ShowAccounts.
                                                                             //Går det att göra på annat sätt?
            Console.WriteLine("Enter account to transfer from: ");
            optionCount = accountList.Count();
            int indexFromAccount = Choice(optionCount);
            int fromAccount = accountList[indexFromAccount - 1].AccountNumber;
            Console.WriteLine("Enter account to transfer to: ");
            int indexToAccount = Choice(optionCount);
            int toAccount = accountList[indexToAccount - 1].AccountNumber;
            Console.WriteLine("Enter amount to transfer: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);    //Finns annan felhanteringslösning här?

            //Transaction transaction = new TransactionFactory().CreateTransaction(amount, fromAccount, toAccount, Id);
            //Id? Är det verkligen en inparameter? Eller är det ett transaktionsid unikt för detta transaktionsobjektet? 
            //Isf borde det väl genereras automatiskt i konstruktorn för transaktionsobjektet?
            //transaction.TransferFunds();
        }
        public void MakeExternalTransaction(User user, AccountDataHandler activeUser)
        {

        }
        

    }
}
