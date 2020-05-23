using ExerciseFive.Core.Models;
using ExerciseFive.Data.Models.FileSystems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseFive.Service.FileSystems
{
    public interface IFileSystemService
    {
        Task<BaseResponse<List<FileSystemSearch>>> SearchFileSystemsAsync(string criteria);
    }
}
