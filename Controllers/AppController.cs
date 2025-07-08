using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    public class AppController : Controller
    {
        // GET: AppController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AppController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       

        

   
    }
}
