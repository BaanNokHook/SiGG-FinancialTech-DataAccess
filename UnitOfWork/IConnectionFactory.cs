using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GM.DataAccess.UnitOfWork
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection Create();
    }
}
