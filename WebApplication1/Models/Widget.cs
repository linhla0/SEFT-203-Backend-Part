using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Widget
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WidgetType { get; set; }
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public Dictionary<string, object> Configs { get; set; }
        public string JSONConfigs
        {
            get => JsonConvert.SerializeObject(Configs);
            set
            {
                Configs = !string.IsNullOrWhiteSpace(value)
                  ? JsonConvert.DeserializeObject<Dictionary<string, object>>(value)
                  : null;
            }
        }
    }
}
