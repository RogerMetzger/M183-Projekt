using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniBlog.Models;

namespace MiniBlog.Repository
{
    public class TokenRepository : Repository
    {
        public TokenRepository(MiniBlogContext db) : base(db)
        {
        }

        public bool CheckToken(int token, int userId)
        {
            try
            {
                Db.Tokens.First(t => t.TokenNr == token && t.UserId == userId && t.Expiry > DateTime.Now);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddToken(Token token)
        {
            Db.Tokens.Add(token);
            Db.SaveChanges();
        }
    }
}