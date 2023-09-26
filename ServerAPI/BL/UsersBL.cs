using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;

namespace BL
{
    public class UsersBL
    {
        public static UsersModel SignUp(UsersModel user)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                try
                {
                    UsersTbl matchUser = db.UsersTbls.FirstOrDefault(u => u.UserEmail == user.UserEmail);
                    if (matchUser == null)
                    {
                        UsersTbl newUser = db.UsersTbls.Add(Converters.UsersConverter.Map(user));
                        db.SaveChanges();
                        return Converters.UsersConverter.Map(newUser);
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static UsersModel Login(string userEmail, string userPassword)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                UsersTbl user = db.UsersTbls.FirstOrDefault(u => u.UserEmail == userEmail && u.UserPassword == userPassword);
                if (user != null)
                {
                    return Converters.UsersConverter.Map(user);
                }
                return null;
            }
        }
        public static bool UpdatePasswordToUser(int userId, string password)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                try
                {
                    UsersTbl user = db.UsersTbls.FirstOrDefault(u => u.UserId == userId);
                    if (user != null)
                    {
                        user.UserPassword = password;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<GetRelevantEmailsForReminder_Model> GetRelevantEmailsRorReminder()
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                return Converters.GetRelevantEmailsForReminder_Converter.Map(db.GetRelevantEmailsForReminders.ToList());
            }
        }
    }
}
