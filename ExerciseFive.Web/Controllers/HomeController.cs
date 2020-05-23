using ExerciseFive.Core.Models;
using ExerciseFive.Data.Models.FileSystems;
using ExerciseFive.Service.FileSystems;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
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

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public async Task<JsonResult> Search([FromUri]string criteria)
        {
            return Json(await _fileSystemService.SearchFileSystemsAsync(criteria), JsonRequestBehavior.AllowGet);
        }
    }
}