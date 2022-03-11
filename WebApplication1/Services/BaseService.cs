using AutoMapper;

namespace WebApplication1.Services
{
    public class BaseService<T> where T : BaseService<T>
    {
        protected readonly DataContext _context;
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;

        public BaseService(DataContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        public BaseService(DataContext context, ILogger<T> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
