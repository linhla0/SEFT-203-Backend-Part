namespace WebApplication1.DTOs.Dashboard
{
    public class DashboardDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string LayoutType { get; set; }
        public List<WidgetDto> Widgets { get; set; }
    }
}
