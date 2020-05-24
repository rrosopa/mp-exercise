using ExerciseFive.Service.FileSystems;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
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

        public ActionResult DownloadFile([FromUri]string localFilePath)
        {
            if (System.IO.File.Exists(localFilePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(localFilePath);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, localFilePath.Split(new string[] { "/" }, System.StringSplitOptions.RemoveEmptyEntries).Last());
            }

            return new EmptyResult();
        }
    }
}