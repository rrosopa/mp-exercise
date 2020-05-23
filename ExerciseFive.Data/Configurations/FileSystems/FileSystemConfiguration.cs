using ExerciseFive.Data.Entities.FileSystems;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ExerciseFive.Data.Configurations.FileSystems
{
	public class FileSystemConfiguration : EntityTypeConfiguration<FileSystem>
    {
        public FileSystemConfiguration()
        {
			this.ToTable("FileSystem");
			this.HasKey(x => x.Id);

			this.Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			this.Property(x => x.Name).HasColumnName("Name").IsRequired();
			this.Property(x => x.FileSystemTypeId).HasColumnName("FileSystemTypeId");
			this.Property(x => x.ParentFileSystemId).HasColumnName("ParentId");
			this.Property(x => x.IsReadOnly).HasColumnName("IsReadOnly");
			this.Property(x => x.Size).HasColumnName("Size");
			this.Property(x => x.CreatedDate).HasColumnName("CreatedDate");

			this.HasRequired(x => x.FileSystemType).WithMany().HasForeignKey(x => x.FileSystemTypeId);
			this.HasOptional(x => x.ParentFileSystem).WithMany().HasForeignKey(x => x.ParentFileSystemId);
		}
    }
}
