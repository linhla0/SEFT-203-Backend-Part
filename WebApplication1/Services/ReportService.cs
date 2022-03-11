using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class ReportService : BaseService<ReportService>, IReportService
    {
        public ReportService(DataContext context, ILogger<ReportService> logger, IMapper mapper)
            : base(context, logger, mapper) { }

        public Dictionary<string, int> Count(string collection, string property)
        {
            if (collection.ToLower().Equals("users")) return null;

            var query = $"SELECT {property} as Value, count({property}) as Count FROM {collection} GROUP BY {property}";

            var dict = _context.Reports.FromSqlRaw(query).ToDictionary(x => x.Value, x => x.Count);
            return dict;
        }
    }
}
