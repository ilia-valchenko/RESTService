using System;
using DAL.Interfacies.Repository;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if(Context != null)
            {
                try
                {
                    Context.SaveChanges();
                }
                catch(DbEntityValidationException exc)
                {
                    foreach (var eve in exc.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    throw;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    // free managed objects
                }

                // free unmanaged objects

                Context?.Dispose();

                disposed = true;
            }
        }

        ~UnitOfWork()
        {
            if(!disposed)
            {
                Dispose(false);
            }
        }

        private bool disposed = false;
    }
}
