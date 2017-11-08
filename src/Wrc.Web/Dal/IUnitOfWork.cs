using System;
using System.Data;

namespace Wrc.Domain.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);
        void Clear();
        void Flush();
    }
}