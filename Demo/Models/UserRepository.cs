using Microsoft.EntityFrameworkCore;
using Sabji_MartDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class UserRepository
    {

        Sabji_MartContext context = new Sabji_MartContext();


        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User checkLogin(User user)
        {
            var entity = context.Users.FirstOrDefault(t => t.EmailAdd == user.EmailAdd && t.Password == user.Password);
            return entity;
        }

        //public void AddUser(User user)
        //{
        //    context.Users.Add(user);
        //    context.SaveChanges();
        //}


        //public IEnumerable<User> AddUser(User user)
        //{
        //    var user1 = new User();
        //    user1.FirstName = user.FirstName;
        //    user1.LastName = user.LastName;
        //    user1.EmailAdd = user.EmailAdd;
        //    user1.PhoneNo = user.PhoneNo;
        //    user1.Address = user.Address;
        //    user1.Password = user.Password;
        //    user1.ConfirmPassword = user.ConfirmPassword;

        //    try
        //    {
        //        context.Users.Add(user);
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    var userinfo = context.Users.ToList();
        //    return userinfo;
        //}
        public User GetUserId(int id)
        {
            return context.Users.Where(user => user.Id == id).FirstOrDefault();

        }
        public int getCount()
        {
            var count = context.Users.Count();
            return count;

        }


        public void UpdateUser(User user)
        {
            context.Entry<User>(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteUserRecord(int id)
        {
            var entity = context.Users.FirstOrDefault(t => t.Id == id);
            context.Users.Remove(entity);
            context.SaveChanges();
        }

    }
}
