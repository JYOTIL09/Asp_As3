using System.Text.Json;
using System.Text.Json.Nodes;

namespace Assignment_3.AppUtilities
{
    public class JSON_Utilities
    {
        public static JsonObject ReadFromFile(string path) 
        {
            JsonObject data = new JsonObject();
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found.");
                    return data;
                }

                string json = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<JsonObject>(json);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting JSON"+ex.Message);
            }
            
            return data;
        }
    }
}
