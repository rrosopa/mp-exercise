using ExerciseFive.Data.Entities.FileSystems;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ExerciseFive.Data.Configurations.FileSystems
{
	public class FileSystemTypeConfiguration : EntityTypeConfiguration<FileSystemType>
    {
		public FileSystemTypeConfiguration()
		{
			this.ToTable("FileSystemType");
			this.HasKey(x => x.Id);

			this.Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			this.Property(x => x.Name).HasColumnName("Name").IsRequired();
		}
	}
}
