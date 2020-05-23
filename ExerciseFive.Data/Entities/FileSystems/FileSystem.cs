using System;

namespace ExerciseFive.Data.Entities.FileSystems
{
    public class FileSystem : BaseEntity
    {
        public string Name { get; set; }
        public int FileSystemTypeId { get; set; }
        public virtual FileSystemType FileSystemType { get; set; }
        public int? ParentFileSystemId { get; set; }
        public virtual FileSystem ParentFileSystem { get; set; }
        public bool IsReadOnly { get; set; }
        public long Size { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
