using System.Text.Json;
using System.Text.Json.Nodes;

namespace Assignment_3.AppUtilities
{
    public class JSON_Utilities
    {
        public static JsonObject ReadFromFile(string path) 
        {
            JsonObject data;
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found.");
                    return default(JsonObject);
                }

                string json = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<JsonObject>(json);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting JSON"+ex.Message);
            }
            
            return default(JsonObject);
        }
    }
}
