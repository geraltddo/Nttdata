using System;
using System.Data;

namespace Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
