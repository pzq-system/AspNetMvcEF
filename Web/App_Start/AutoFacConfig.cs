using Autofac;
using Autofac.Integration.Mvc;


using System;
using System.Reflection;
using System.Web.Mvc;

namespace Web
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            try
            {

                var builder = new ContainerBuilder();

                //告诉autofac,将创建的控制器存放在那个程序集
                Assembly controleAss = Assembly.Load("Web");
                builder.RegisterControllers(controleAss);

                //builder.RegisterType<BaseDbContext>().As<DbContext>().InstancePerRequest();

                //Assembly repAss = Assembly.Load("Repository");
                //builder.RegisterTypes(repAss.GetTypes()).AsImplementedInterfaces();

                Assembly bllAss = Assembly.Load("Service");
                builder.RegisterTypes(bllAss.GetTypes()).AsImplementedInterfaces();

                //创建一个Autofac容器
                var ioc = builder.Build();

                //将MVC的控制器对象实例 交给autofac来创建
                DependencyResolver.SetResolver(new AutofacDependencyResolver(ioc));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}