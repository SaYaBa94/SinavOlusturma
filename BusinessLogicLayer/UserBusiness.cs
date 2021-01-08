using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class userBusiness
    {
        public static User GetUser(string name, string password) {
            return UserDAL.GetUser(name, password);
        }

        public static User GetUser(int userId)
        {
            return UserDAL.GetUser(userId);
        }
    }
}
