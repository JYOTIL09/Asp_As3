using Assignment_3.AppUtilities;
using Assignment_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Assignment_3.Controllers
{
    public class AppController : Controller
    {
        QuestionsList questionsList;
        JsonArray _arr = new JsonArray();
        private readonly IQuestionService _questionService;

        public AppController(IQuestionService questionService)
        {
            _questionService = questionService;
            this.questionsList = new QuestionsList();

        }

        // GET: AppController
        public ActionResult Index()
        {
            
          TopicsList topicsList = new TopicsList();
          JsonArray _list = topicsList.getList();
           

            return View(_list);
        }

        // GET: AppController/Quiz/
        public ActionResult Quiz(string quiz_topic,string topic_id)
        {
            ViewBag.title = quiz_topic;
            ViewBag.topicId = topic_id;
            JsonObject questions_object = new JsonObject();
            JsonArray questions_array = new JsonArray();
            try
            {
            questions_object = questionsList.setQuestions(topic_id);
            this._arr = questions_object["questions"]?.AsArray();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error while reading questions of given topic: "+e.Message);
            }
            return View(questions_array);
        }

        public ActionResult QuizQuestion(string id, string topicId)
        {
            var questionsJson = _questionService.GetQuestionsJson();
            var topicObj = questionsJson[topicId]?.AsObject();
            var questions = topicObj["questions"].AsArray();

            int _id = int.Parse(id);

            // ✅ Redirect to result if quiz is over
            if (_id > questions.Count)
            {
                return RedirectToAction("ShowResult", new { topicId = topicId });
            }

            var questionObject = questions[_id - 1].AsObject();

            ViewBag.previd = _id - 1;
            ViewBag.nextid = _id + 1;
            ViewBag.topicId = topicId;
            ViewBag.questionId = id;

            return View(questionObject);
        }



        [HttpPost]
        public IActionResult SubmitAnswer(string questionId, string topicId, string selectedOption)
        {
            var answers = HttpContext.Session.GetString("UserAnswers");
            Dictionary<string, string> userAnswers;

            if (answers != null)
            {
                userAnswers = JsonSerializer.Deserialize<Dictionary<string, string>>(answers);
            }
            else
            {
                userAnswers = new Dictionary<string, string>();
            }

            userAnswers[questionId] = selectedOption;

            HttpContext.Session.SetString("UserAnswers", JsonSerializer.Serialize(userAnswers));

            int nextId = int.Parse(questionId) + 1;
            return RedirectToAction("QuizQuestion", new { id = nextId, topicId = topicId });
        }

        public IActionResult ShowResult(string topicId)
        {
            var answersJson = HttpContext.Session.GetString("UserAnswers");
            var questionsJson = _questionService.GetQuestionsJson();
            var topicObj = questionsJson[topicId]?.AsObject();
            var questions = topicObj["questions"].AsArray();

            var userAnswers = JsonSerializer.Deserialize<Dictionary<string, string>>(answersJson);
            int score = 0;

            foreach (var kvp in userAnswers)
            {
                int qId = int.Parse(kvp.Key) - 1;
                var correctAnswer = questions[qId].AsObject()["answer"]?.ToString();
                if (kvp.Value == correctAnswer)
                {
                    score++;
                }
            }

            ViewBag.Score = score;
            ViewBag.Total = questions.Count;
            return View();
        }





    }
}
