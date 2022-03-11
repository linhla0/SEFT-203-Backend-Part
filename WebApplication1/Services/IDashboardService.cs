using WebApplication1.DTOs.Dashboard;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDashboardService
    {
        Dashboard Update(int id, UpdateDashboardDto dashboard);
        Dashboard Get(int id);
        IEnumerable<Dashboard> GetAll();
    }
}
