using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Model;

namespace MVCTest.DB.DbOperation
{
    public class AccountOperation
    {
        public int AddUser(UserModel model)
        {
            using (var context = new MyDBEntities())
            {
                User user = new User()
                {
                    UserName=model.UserName,
                    Password=model.Password,
                };
                context.User.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }

        public bool loginUser(UserModel model)
        {
           
            using (var context = new MyDBEntities())
            {
               var isValid = context.User.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                if (isValid!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }
    }
}
