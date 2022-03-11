using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Dashboard
{
    public class UpdateDashboardDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string LayoutType { get; set; }
        public List<WidgetDto> Widgets { get; set; }
    }
}
