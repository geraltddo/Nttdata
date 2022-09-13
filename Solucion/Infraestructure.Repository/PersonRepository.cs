using Common;
using Domain.Entity;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repository
{
    public class PersonRepository : GenericRepository<Persona>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext) : base(dbContext) { }
    }
}
