using Assignment_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Assignment_3.Controllers
{
    public class AppController : Controller
    {
        // GET: AppController
        public ActionResult Index()
        {
            
          TopicsList topicsList = new TopicsList();
          JsonArray _list = topicsList.getList();
           

            return View(_list);
        }

        // GET: AppController/Quiz/
        public ActionResult Quiz(string quiz_topic)
        {
            return View();
        }

       

        

   
    }
}
