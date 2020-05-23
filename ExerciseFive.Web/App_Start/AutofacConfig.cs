using Autofac;
using Autofac.Integration.Mvc;
using ExerciseFive.Data.Contexts;
using ExerciseFive.Service;
using System.Web.Mvc;

namespace ExerciseFive.Web.App_Start
{
	public class AutofacConfig
    {		
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			// register dependencies in controllers
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// register dependencies in filter attributes
			builder.RegisterFilterProvider();

			// register dependencies in custom views
			builder.RegisterSource(new ViewRegistrationSource());

			// register data layer
			builder.RegisterType<AppDbContext>().As<IAppDbContext>().InstancePerLifetimeScope();

			// register service layer
			builder.RegisterModule<ServiceModule>();

			var container = builder.Build();

			// Set MVC DI resolver to use our Autofac container
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}