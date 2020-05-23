using ExerciseFive.Core.Constants;
using ExerciseFive.Core.Models;
using ExerciseFive.Data.Contexts;
using ExerciseFive.Data.Models.FileSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseFive.Service.FileSystems
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IAppDbContext _appDbContext;

        public FileSystemService(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BaseResponse<List<FileSystemSearch>>> SearchFileSystemsAsync(string criteria)
        {
            var response = new BaseResponse<List<FileSystemSearch>>();

            try
            {
                response.Data = await _appDbContext.SpFileSearchAsync(criteria);
            }
            catch(Exception ex)
            {
                // add logging here
                response.Errors.Add(new Error(ErrorCode.FileSystemServiceError001));
            }

            return response;
        }
    }
}
