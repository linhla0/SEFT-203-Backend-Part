using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;
        private readonly IMapper _mapper;
        private ILogger<ReportController> _logger;

        public ReportController(IReportService service, IMapper mapper, ILogger<ReportController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("_countBy/{collection}/{field}")]
        public IActionResult GetAll(string collection, string field)
        {
            var reports = _service.Count(collection, field);
            return Ok(reports);
        }
    }
}
