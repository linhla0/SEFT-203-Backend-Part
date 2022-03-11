namespace WebApplication1.DTOs.Dashboard
{
    public class WidgetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WidgetType { get; set; }
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public Dictionary<string, object> Configs { get; set; }
    }
}
