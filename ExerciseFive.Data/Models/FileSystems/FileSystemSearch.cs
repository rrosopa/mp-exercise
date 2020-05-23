using System;

namespace ExerciseFive.Data.Models.FileSystems
{
    public class FileSystemSearch
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int FileSystemTypeId { get; set; }
        public bool IsReadOnly { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString => CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK");
        public long? Size { get; set; }
        public string Path { get; set; }
    }
}
