using Common;
using Domain.Entity;
using Infraestructure.Interface;
using System;

namespace Infraestructure.Repository
{
    public class ClientRepository : GenericRepository<Cliente>, IClientRepository
    {
        public ClientRepository(IDbContext dbContext) : base(dbContext) { }
    }
}
