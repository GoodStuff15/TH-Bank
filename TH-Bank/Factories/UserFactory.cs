

namespace TH_Bank
{
    public class UserFactory
    {
        public User CreateUser(string username, string password, string? fName, string? lName, string userInput)
        {
            var sys = new SystemDataHandler();
            

            User user = null;

            if(userInput == "Customer")
            {
                string id = $"CUS{sys.GetCustomerIDCount().ToString("D8")}";
                sys.Save("Customer", sys.GetCustomerIDCount() + 1);
                user = new Customer(id, username, password, fName, lName);
            }
            else if(userInput == "Admin")
            {
                string id = $"ADM{sys.GetAdminIDCount().ToString("D8")}";
                sys.Save("Admin", sys.GetCustomerIDCount() + 1);
                user = new Admin(id, username, password);
            }
            else
            {
                throw new Exception($"Invalid user type, can't create {userInput}");
            }
            return user;
        }

        

    }
}
