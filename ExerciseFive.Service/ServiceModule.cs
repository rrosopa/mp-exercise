using Autofac;
using ExerciseFive.Service.FileSystems;

namespace ExerciseFive.Service
{
	public class ServiceModule : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<FileSystemService>().As<IFileSystemService>().InstancePerLifetimeScope();
		}
	}
}
