﻿
namespace TH_Bank
{
    public class SystemDataHandler
    {
        public string FilePath { get; set; }
        private int _customerIDCount;
        private int _adminIDCount;
        

        public SystemDataHandler()
        {
            FilePath = FilePaths.SystemPath;
            string[] openFile = File.ReadAllLines(FilePath);

            foreach (string line in openFile)
            {
                if (line.Contains("CustomerIDCount"))
                {
                    string[] split = line.Split('|');
                    _customerIDCount = int.Parse(split[1]);
                }
                else if (line.Contains("AdminIDCount"))
                {
                    string[] split = line.Split('|');
                    _adminIDCount = int.Parse(split[1]);
                }
            }
        }
        public int GetCustomerIDCount()
        {
            return _customerIDCount;
        }
        public int GetAdminIDCount()
        {
            return _adminIDCount;
        }

        public void Save(string valueToChange, int saveThis)
        {
            string[] openFile = File.ReadAllLines(FilePath);

            foreach(string line in openFile)
            {
                if(line.Contains(valueToChange))
                {
                   int changeThis = Array.IndexOf(openFile, line);

                    openFile[changeThis] = $"{valueToChange}IDCount|{saveThis}";
                }
            }
            File.WriteAllLines(FilePath, openFile);
        }
    }

}