using System.Linq;
using System.Web.Mvc;
using JobDescriptionTagger.Database;
using JobDescriptionTagger.Models;
using JobDescriptionTagger.Services;

namespace JobDescriptionTagger.Controllers
{
    public class MainController : Controller
    {
        private readonly UserTagService _userTags;

        public MainController()
        {
            _userTags = new UserTagService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new UserTagModel();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(UserTagModel model)
        {
            _userTags.SaveTags(model);

            model.Description = string.Empty;

            return View(model);
        }

        public ActionResult Tags()
        {
            ViewBag.Message = "See all tags generated.";

            return View();
        }

        public ActionResult Inferences()
        {
            ViewBag.Message = "Set up inferences.";

            return View();
        }
    }
}