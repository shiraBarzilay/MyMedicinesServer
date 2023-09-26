using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;

namespace BL.Converters
{
    public static class UsersConverter
    {
        public static UsersTbl Map(UsersModel user)
        {
            return new UsersTbl
            {
                UserId = user.UserId,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
                UserAddress = user.UserAddress,
                UserFirstname = user.UserFirstname,
                UserLastname = user.UserLastname,
                UserBirthday = user.UserBirthday,
                UserCity = user.UserCity
            };
        }
        public static UsersModel Map(UsersTbl user)
        {
            return new UsersModel
            {
                UserId = user.UserId,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
                UserAddress = user.UserAddress,
                UserFirstname = user.UserFirstname,
                UserLastname = user.UserLastname,
                UserBirthday = user.UserBirthday,
                UserCity = user.UserCity
            };
        }
    }
}
