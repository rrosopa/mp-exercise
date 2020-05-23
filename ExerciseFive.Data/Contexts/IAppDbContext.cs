using ExerciseFive.Data.Entities.FileSystems;
using ExerciseFive.Data.Models.FileSystems;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ExerciseFive.Data.Contexts
{
    public interface IAppDbContext
    {
        DbSet<FileSystem> FileSystems { get; set; }
        DbSet<FileSystemType> FileSystemTypes { get; set; }

        Task<List<FileSystemSearch>> SpFileSearchAsync(string criteria);
    }
}
