using NHibernate;
using NHibernate.Cfg;
using System.IO;
using System.Web;
namespace SportFinderApi.Repository
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            //var configurationPath = HttpContext.Current.Server.MapPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Configuration\hibernate.cfg.xml");
            configuration.Configure(@"C:\Users\Tomislav\Documents\Visual Studio 2017\Projects\SportFinderApi\Repository\Configuration\hibernate.cfg.xml");
            //var userConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mapping\User.hbm.xml");
            configuration
                .AddFile(@"C:\Users\Tomislav\Documents\Visual Studio 2017\Projects\SportFinderApi\Repository\Mapping\User.hbm.xml")
                .AddFile(@"C:\Users\Tomislav\Documents\Visual Studio 2017\Projects\SportFinderApi\Repository\Mapping\City.hbm.xml")
                .AddFile(@"C:\Users\Tomislav\Documents\Visual Studio 2017\Projects\SportFinderApi\Repository\Mapping\Sport.hbm.xml")
                .AddFile(@"C:\Users\Tomislav\Documents\Visual Studio 2017\Projects\SportFinderApi\Repository\Mapping\Event.hbm.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}