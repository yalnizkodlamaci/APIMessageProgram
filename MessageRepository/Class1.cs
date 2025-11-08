using System.Text.Json;

namespace MessageRepository
{
    public class MessageRepo
    {

        private List<string> Message = new List<string>();
        public readonly string path = Path.Combine(AppContext.BaseDirectory ,"../" , "../" , "../" , "../", "MessageRepository/" , "message.json");
        public void Add(string message) 
        {
            Message.Add(message);
        }

        public void Save() 
        {
            var fullpath = Path.GetFullPath(path);

            var formatted = Message.Select(m => new { Message = m }).ToList();

            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsondata = JsonSerializer.Serialize(formatted, options);

            File.WriteAllText(fullpath, jsondata);
        }
        


    }
}
