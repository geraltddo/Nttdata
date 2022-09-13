using Common;
using Domain.Entity;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repository
{
    public class AccountRepository : GenericRepository<Cuenta>, IAccountRepository
    {
        public AccountRepository(IDbContext dbContext) : base(dbContext) { }
    }
}
