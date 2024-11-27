﻿using System.Security.Principal;


namespace TH_Bank
{
    public class AccountDataHandler : IDataHandler<Account>
    {
        public string FilePath { get; set; }

        public AccountDataHandler()
        {
            FilePath = FilePaths.AccountPath;
        }

        public void Delete(Account deleteThis)
        {
            string[] openFile = File.ReadAllLines(FilePath);

            // Finds the row that contains the account to be deleted.
            int deleterow = Array.IndexOf(openFile, deleteThis.ToString());

            // Loops trough accounts starting at deleted row, and shifts them one to the left,
            // writing over the deleted account info.
            for (int i = deleterow + 1; i < openFile.Length; i++)
            {
                openFile[i - 1] = openFile[i];
            }

            File.WriteAllLines(FilePath, openFile);


        }

        public Account Load()
        {
            throw new NotImplementedException();
        }

        public Account Load(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<Account> LoadAll()
        {
            string[] openFile = File.ReadAllLines(FilePath);

            var accounts = new List<Account>();

            foreach (string line in openFile)
            {

                if (line.Contains("SalaryAccount"))
                {
                    string[] variables = line.Split('|');

                    string ownerid = variables[0];
                    int accountnumber = int.Parse(variables[1]);
                    decimal balance = decimal.Parse(variables[2]);
                    string currency = variables[3];

                    accounts.Add(new SalaryAccount(balance, currency, accountnumber, ownerid));
                }
                else if (line.Contains("SavingsAccount"))
                {
                    string[] variables = line.Split('|');

                    string ownerid = variables[0];
                    int accountnumber = int.Parse(variables[1]);
                    decimal balance = decimal.Parse(variables[2]);
                    string currency = variables[3];

                    accounts.Add(new SavingsAccount(balance, currency, accountnumber, ownerid));
                }
            }

            return accounts;
        }

        public List<Account> LoadAll(string userid)
        {
            string[] openFile = File.ReadAllLines(FilePath);

            var accounts = new List<Account>();

            foreach (string lines in openFile)
            {
                if (lines.Contains(userid) && lines.Contains("SalaryAccount"))
                {
                    string[] variables = lines.Split('|');

                    string ownerid = variables[0];
                    int accountnumber = int.Parse(variables[1]);
                    decimal balance = decimal.Parse(variables[2]);
                    string currency = variables[3];

                    accounts.Add(new SalaryAccount(balance, currency, accountnumber, ownerid));
                }
                else if (lines.Contains(userid) && lines.Contains("SavingsAccount"))
                {
                    string[] variables = lines.Split('|');

                    string ownerid = variables[0];
                    int accountnumber = int.Parse(variables[1]);
                    decimal balance = decimal.Parse(variables[2]);
                    string currency = variables[3];
                    
                    
                    // decimal amount, string currency, int accountNumber, string ownerID
                    // $"{OwnerID}|{AccountNumber}|{Balance}|{Currency}|{AccountType}"

                    accounts.Add(new SavingsAccount(balance, currency, accountnumber, ownerid));
                }
            }
            return accounts;
        }

        public void Save(Account saveThis)
        {
            string[] openFile = File.ReadAllLines(FilePath);

            string x = Array.Find(openFile, y => y.Contains(saveThis.AccountNumber.ToString()));

            if (x == null)
            {
                openFile = openFile.Append(saveThis.ToString()).ToArray();

            }
            else
            {
                openFile[Array.IndexOf(openFile, Array.Find(openFile, y => y.Contains(saveThis.AccountNumber.ToString())))] = saveThis.ToString();
            }

            File.WriteAllLines(FilePath, openFile);
        }

        public void SaveAll(List<Account> saveList)
        {
            throw new NotImplementedException();
        }
    }
}