using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly IMapper _mapper;
        private ILogger<TaskController> _logger;

        public TaskController(ITaskService service, IMapper mapper, ILogger<TaskController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string keyword)
        {
            var tasks = _service.GetAll(keyword);
            var model = _mapper.Map<IList<Task>>(tasks);
            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var task = _service.Get(id);

            if (task == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Task>(task);
            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Task model)
        {
            var task = _service.Get(id);

            if (task == null)
            {
                return NotFound();
            }
            else if (task.Id != IdentityHelper.UserId)
            {
                return Forbid();
            }

            var savedTask = _service.Update(id, model);
            return Ok(savedTask);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Task model)
        {
            var createdTask = _service.Create(model);
            return Ok(createdTask);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var task = _service.Get(id);

            if (task == null)
            {
                return NotFound();
            }
            else if (task.Id != IdentityHelper.UserId)
            {
                return Forbid();
            }

            var deletedTask = _service.Delete(id);
            return Ok(deletedTask);
        }
    }
}
