using Common;
using Domain.Entity;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repository
{
    public class TransactionRepository : GenericRepository<Movimiento>, ITransactionRepository
    {
        public TransactionRepository(IDbContext dbContext) : base(dbContext) { }
    }
}
