using System;

namespace Wrc.Domain.Dal
{
    public interface IGenericTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}