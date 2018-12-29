using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHibernate_Crud.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql7
                .ConnectionString(@"Data Source=DB; Initial Catalog=CadastroDB; Integrated Security=True")
                .ShowSql()
                )
            .Mappings(m =>
            m.FluentMappings
            .AddFromAssemblyOf<Aluno>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
            .Create(false, false))
            .BuildSessionFactory();

          return sessionFactory.OpenSession();
                
        }
    }
}