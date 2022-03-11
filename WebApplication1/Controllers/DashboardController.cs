using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Dashboard;
using WebApplication1.Helpers;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DashboardsController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly IMapper _mapper;
        private ILogger<DashboardsController> _logger;

        public DashboardsController(IDashboardService service, IMapper mapper,
            ILogger<DashboardsController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dashboards = _service.GetAll();
            var model = _mapper.Map<IList<DashboardDto>>(dashboards);
            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public IActionResult SaveDashboard(int id, [FromBody] UpdateDashboardDto model)
        {
            var dashboard = _service.Get(id);

            if (dashboard == null)
            {
                return NotFound();
            }
            else if (dashboard.UserId != IdentityHelper.UserId)
            {
                return Forbid();
            }

            var savedDashboard = _service.Update(id, model);
            return Ok(savedDashboard);
        }
    }
}
