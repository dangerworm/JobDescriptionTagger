using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobDescriptionTagger.Database;
using JobDescriptionTagger.Models;
using JobDescriptionTagger.Services;

namespace JobDescriptionTagger.Controllers
{
    public class MainController : Controller
    {
        private readonly UserTagService _userTags;
        private readonly TagService _tags;

        public MainController()
        {
            _userTags = new UserTagService();
            _tags = new TagService();
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

            ModelState.Clear();

            return Index();
        }

        //public ActionResult Users()
        //{
        //    //var result = _users.GetAll();

        //    //return View(result.Value);
        //}

        public ActionResult Tags()
        {
            ViewBag.Message = "See all tags generated.";

            var result = _tags.GetTags(includeIgnored: true);

            return View(result.Value);
        }

        public ActionResult TagLinks()
        {
            ViewBag.Message = "See which tags are common between users.";

            var result = _userTags.GetCommonTags(includeIgnored: true);

            return View(result.Value);
        }

        public ActionResult Inferences()
        {
            ViewBag.Message = "Set up inferences.";

            return View();
        }
    }
}