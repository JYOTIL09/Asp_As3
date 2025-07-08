using System.Text.Json;

namespace Assignment_3.AppUtilities
{
    public class JSON_Utilities
    {
        public static T ReadFromFile<T>(string path) 
        {
            T data;
            try
            {
                string json = File.ReadAllText(path);
                data = JsonSerializer.Deserialize<T>(json);
                return data;
            }
            catch (Exception ex)
            {
                data  = JsonSerializer.Deserialize<T>("{}");
            }
            finally {
                Console.WriteLine("JSON ReadfromFile method executed");
            
            }
            return data;
        }
    }
}
