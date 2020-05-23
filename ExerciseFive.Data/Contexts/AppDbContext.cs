using ExerciseFive.Data.Configurations.FileSystems;
using ExerciseFive.Data.Entities.FileSystems;
using ExerciseFive.Data.Models.FileSystems;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ExerciseFive.Data.Contexts
{
	public class AppDbContext : DbContext, IAppDbContext
    {
		public AppDbContext() : base("AppDbContext")
		{
			//We set the EF DB Initializer to null, this will prevent the model and schema mismatch error
			//Database.SetInitializer<AppDbContext>(null);
		}

		public virtual DbSet<FileSystem> FileSystems { get; set; }
		public virtual DbSet<FileSystemType> FileSystemTypes { get; set; }

		public virtual async Task<List<FileSystemSearch>> SpFileSearchAsync(string criteria)
		{
			return await this.Database
				.SqlQuery<FileSystemSearch>("EXEC usp_FileSearch @criteria", new SqlParameter("@criteria", criteria))
				.ToListAsync();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new FileSystemConfiguration());
			modelBuilder.Configurations.Add(new FileSystemTypeConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
