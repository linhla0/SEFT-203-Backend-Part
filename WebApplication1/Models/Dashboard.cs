namespace WebApplication1.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string LayoutType { get; set; }
        public List<Widget> Widgets { get; set; }
    }
}
