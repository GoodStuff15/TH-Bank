﻿namespace Shitlords_Bankomat
{
    internal class Admin : User
    {
        public override string UserType { get; } = "Admin";
        public Admin(string id, string passWord, string userName) : base(id, passWord, userName)
        {
        }

        public override string ToString()
        {
            return $"{Id}|{UserName}|{PassWord}|{UserType}";
        }
    }
}
