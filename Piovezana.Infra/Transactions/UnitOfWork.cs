using Piovezana.Infra.Persistencia.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Piovezana.Infra.Transactions
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly PiovezanaContexto _context;
        public UnitOfWork(PiovezanaContexto context)
        {
            _context = context;
        }

        public void comit()
        {
            _context.SaveChanges();
        }

       
    }
}
