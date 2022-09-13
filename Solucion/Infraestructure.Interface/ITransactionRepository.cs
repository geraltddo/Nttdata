using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Interface
{
    public interface ITransactionRepository: IGenericRepository<Movimiento>
    {
    }
}
