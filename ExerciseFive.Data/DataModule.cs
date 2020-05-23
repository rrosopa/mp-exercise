using Autofac;
using ExerciseFive.Data.Contexts;

namespace ExerciseFive.Data
{
    public class DataModule : Module
    {
        private readonly string _connectionString;

        public DataModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().As<IAppDbContext>().InstancePerLifetimeScope();
        }
    }
}
