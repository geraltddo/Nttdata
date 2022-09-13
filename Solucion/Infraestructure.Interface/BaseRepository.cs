using Common;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Interface
{
    public class BaseRepository<T> where T : class
    {
        protected IDbContext _dbContext;
        protected IDbConnection _dbConnection;
        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            try
            {
                _dbContext.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error conexión {ex.Message}");
            }

            _dbConnection = dbContext.Database.GetDbConnection();

            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
        }
    }
}
