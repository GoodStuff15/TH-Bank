using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH_Bank
{
    public class Format
    {
        public static int Choice(int max) // Method to only accept valid keypress.
        {
            bool isNumber;
            int num = 0;
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                // Checks if the choice is a number
                // If it is, converts keypress
                // into an int. 
                isNumber = Char.IsAsciiDigit(key.KeyChar);
                if (isNumber)
                {
                    num = Convert.ToInt32(key.KeyChar.ToString());
                }

            } while (!isNumber || num > max || num == 0); // exits while loop only if number is not bigger
                                              // than the max index of the active users accounts.
            return num;
        }

        public static decimal DecimalInput()
        {
            bool isNumber = false;
            string numberString = "";
            decimal number;
            ConsoleKeyInfo cki;

            do
            {   // Takes input and checks if it is a number
                cki = Console.ReadKey(true);
                isNumber = decimal.TryParse(cki.KeyChar.ToString(), out decimal check);

                if (cki.Key != ConsoleKey.Backspace)
                {
                    if (isNumber) //if it is a number, adds to string of numbers 
                    {
                        // Makes sure user can only type two digits after entering a comma
                        if (numberString.Contains(",") && numberString.IndexOf(",") < numberString.Length - 2)
                        {
                            // do nothing
                        }
                        else
                        {
                            numberString += cki.KeyChar;
                            Console.Write(cki.KeyChar);
                        }
                    }
                    else if (!numberString.Contains(",") && cki.Key == ConsoleKey.OemComma)
                    { // if key pressed is comma and there is no comma in string, adds a comma.
                        numberString += cki.KeyChar;
                        Console.Write(cki.KeyChar);
                    }
                } // Backspace key delete characters from the string
                else if (cki.Key == ConsoleKey.Backspace && numberString.Length > 0)
                {
                    numberString = numberString.Substring(0, (numberString.Length - 1));
                    Console.Write("\b \b");
                }
                // Exits while loop when user presses enter after entering at least 1 number
            } while (cki.Key != ConsoleKey.Enter || numberString.Length == 0);

            Console.WriteLine();

            // The string is converted to double and returned.
            // CurrentCulture used to make sure Ören are represented correctly.
            decimal.TryParse(numberString, CultureInfo.CurrentCulture, out number);

            return number;
        }


        public static int IntegerInput(int numberOfDigits)
        {
            bool isNumber = false;
            string numberString = "";
            int number;
            ConsoleKeyInfo cki;

            do
            {   // Takes input and checks if it is a number
                cki = Console.ReadKey(true);
                isNumber = int.TryParse(cki.KeyChar.ToString(), out int check);

                if (cki.Key != ConsoleKey.Backspace)
                {
                    if (isNumber) //if it is a number, adds to string of numbers 
                    {
                        if (numberString.Length < numberOfDigits)
                        {
                            numberString += cki.KeyChar;
                            Console.Write(cki.KeyChar);
                        }
                    }
                } // Backspace key delete characters from the string
                else if (cki.Key == ConsoleKey.Backspace && numberString.Length > 0)
                {
                    numberString = numberString.Substring(0, (numberString.Length - 1));
                    Console.Write("\b \b");
                }
                // Exits while loop when user presses enter after entering at least 1 number
            } while (cki.Key != ConsoleKey.Enter || numberString.Length == 0);

            Console.WriteLine();

            // The string is converted to int and returned.
            int.TryParse(numberString, out number);
            return number;
        }

       

        private static Random randaccount = new Random();
        public static int UniqueAccountNo(string account)
        {
            string choice = account == "Salaryaccount" ? "11" : "22";
            int rndAcc = randaccount.Next(1000, 10000);
            string accountNumber = choice + rndAcc.ToString();
            return int.Parse(accountNumber);
        }

    }
}
