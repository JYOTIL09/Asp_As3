using System.Text.Json.Nodes;

namespace Assignment_3.AppUtilities
{
    public interface IQuestionService
    {
        JsonObject GetQuestionsJson();
    }

    public class QuestionService : IQuestionService
    {
        private readonly JsonObject _questionsJson;

        public QuestionService()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Database", "questionnaire.json");
            _questionsJson = JSON_Utilities.ReadFromFile(path);
        }

        public JsonObject GetQuestionsJson()
        {
            return _questionsJson;
        }

    }
}
