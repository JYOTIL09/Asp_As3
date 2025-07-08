using Assignment_3.AppUtilities;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Assignment_3.Models
{
    public class TopicsList
    {

        JsonObject _topicList;
        public TopicsList() { 
        
        string _fileName = "topics.json";
        string _fileFolder = "Database";
        string _filePath = Path.Combine(AppContext.BaseDirectory, _fileFolder, _fileName);

            this._topicList = JSON_Utilities.ReadFromFile( _filePath );
            getList();
        }

        public JsonArray getList()
        {
            JsonArray topicsArray = _topicList["topics"]?.AsArray();

            if (topicsArray != null)
            {
                foreach (JsonNode? node in topicsArray)
                {
                    JsonObject? topicObj = node?.AsObject();
                    if (topicObj != null)
                    {
                        string id = topicObj["id"]?.ToString();
                        string title = topicObj["title"]?.ToString();

                        Console.WriteLine($"ID: {id}, Title: {title}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No 'topics' array found in the JSON.");
            }


            return topicsArray;
        }
       

    }
}
