using ExerciseFive.Core.Models;
using ExerciseFive.Data.Models.FileSystems;
using ExerciseFive.Service.FileSystems;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExerciseFive.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileSystemService _fileSystemService;

        public HomeController(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public class SearchResult
        {
            public string Criteria { get; set; }
            public BaseResponse<List<FileSystemSearch>> Response { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult> Index(string criteria = null)
        {
            return View(new SearchResult
            {
                Criteria = criteria,
                Response = await _fileSystemService.SearchFileSystemsAsync(criteria)
        });
        }
    }
}