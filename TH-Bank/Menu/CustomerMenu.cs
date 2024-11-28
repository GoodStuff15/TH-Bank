
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
            Console.Clear();
            LogoText();
            DrawBorder();
            foreach (string item in _menu)
            {
                DrawMenuItem(item);
            }
            DrawBorder();
            MenuCustomer();
        }


        public void MenuCustomer()
        {
            optionCount = _menu.Length; // Combined with Choice method from MenuClass wrongful inputs can't be made.
            access = true;
            while (access)
            {
                int customerChoice = Choice(optionCount); 
                switch (customerChoice)
                {

                    case 1:
                        ShowAccounts(ActiveUserSingleton.GetInstance(),new AccountDataHandler());
                        break;

                    case 2:
                        //Show transactions.
                        // Logger.
                        break;

                    case 3:
                        // Transfer between accounts.
                        break;

                    case 4:
                        //Transfer between customers.
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
        public override void ShowAccounts(User user, AccountDataHandler activeUser)
        {
            Console.Clear();

            int width = 20;
            int totalWidth = 60;
            string text = $".:{user.UserName}'s Accounts:.";
            int padding = (totalWidth - text.Length -4) / 2;
            string centeredText = new string('.',padding) + text + new string('.',padding);
            ConsoleColor textColor;
            List<Account> accountList = activeUser.LoadAll(user.Id);

            Console.WriteLine(centeredText);

            Console.WriteLine(new string('-', 60));
            Console.WriteLine(
                $"{CenterText(".:Account Type:.", width)}" +
                $"{CenterText(".:Account Number:.", width)}" + 
                $"{CenterText(".:Balance:.", width)}");
            Console.WriteLine(new string('-', 60));

            foreach (var acc in accountList)
            {
                if(acc.Balance < 500)
                {
                    textColor = ConsoleColor.Red;
                }
                else
                {
                    textColor= ConsoleColor.Green;
                }
                Console.ForegroundColor = textColor;

                Console.WriteLine(
                    $"{CenterText(acc.AccountType, width)}" +
                    $"{CenterText(acc.AccountNumber.ToString(), width)}" +               
                    $"{CenterText(acc.Balance.ToString("C"), width)}");

                Console.ResetColor();
            }
            Console.WriteLine(new string('-', 60));
            Console.Write("Press any key to go back.");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        public string CenterText(string text, int width) // A method to align the text when showing accounts.
        {
            int padding = (width - text.Length) / 2;
            string paddedText = text.PadLeft(padding + text.Length);
            paddedText = paddedText.PadRight(width);
            return paddedText;
        }
    }
}
