using Assignment_3.AppUtilities;
using System.Text.Json.Nodes;

namespace Assignment_3.Models
{
    public class QuestionsList
    {
        JsonObject _questions_json;
        public JsonArray _questions_list { get; set; }= new JsonArray();
        public QuestionsList()
        {

            string _fileName = "questionnaire.json";
            string _fileFolder = "Database";
            string _filePath = Path.Combine(AppContext.BaseDirectory, _fileFolder, _fileName);

            this._questions_json = JSON_Utilities.ReadFromFile(_filePath);
            
        }

        public JsonObject setQuestions(string topicId)
        {
            JsonObject questions_object = _questions_json[topicId]?.AsObject();
            if (questions_object == null)
            {
                throw new Exception("Quiz topic not found");
            }
            this._questions_list = questions_object["questions"]?.AsArray();
            Console.WriteLine(_questions_list[0]["question"]);
            return questions_object;
        }

        public JsonObject getQuestion(int id)
        {
            JsonObject _question = this._questions_list[id]?.AsObject();
            return _question;
        }
    }
}
