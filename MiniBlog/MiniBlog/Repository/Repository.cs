using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniBlog.Models;

namespace MiniBlog.Repository
{
    /**
     * Repository-Pattern. Dieses Pattern regelt den Zugriff von Business Logik auf die Datenbank.
     */
    public abstract class Repository
    {
        protected MiniBlogContext Db;
        protected Repository(MiniBlogContext db)
        {
            this.Db = db;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}