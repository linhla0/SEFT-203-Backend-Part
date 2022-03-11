namespace WebApplication1.Services
{
    public interface IReportService
    {
        Dictionary<string, int> Count(string collection, string property);
    }
}
