using System;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Wrc.Domain.Models.Replays;

namespace Wrc.Domain.Dal
{
    public class NhUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _configurationFile;

        private ISessionFactory _sessionFactory;

        public NhUnitOfWorkFactory(string configurationFile = null)
        {
            _configurationFile = configurationFile;
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                lock (this)
                {
                    if (_sessionFactory == null)
                    {
                        BuildSessionFactory();
                    }
                }

                return _sessionFactory;
            }
        }

        private void BuildSessionFactory()
        {
            try
            {
                Configuration config = new Configuration();
                _sessionFactory = Fluently.Configure(config)
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString("abcde").ShowSql)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Replay>())
                    .BuildSessionFactory();
            }
            catch (Exception)
            {
                _sessionFactory = null;
                throw;
            }
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new NhUnitOfWork(SessionFactory.OpenSession());
        }
    }
}