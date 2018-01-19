using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniBlog.Models;

namespace MiniBlog.Repository
{
    public class LoginRepository : Repository
    {
        public LoginRepository(MiniBlogContext db) : base(db)
        {
        }

        public bool CheckIfUserExists(string username)
        {
            return Db.Users.Any(x => x.Username == username);
        }
        public User GetUserByName(string username)
        {
            return this.Db.Users.First(x => x.Username == username);
        }
    }
}