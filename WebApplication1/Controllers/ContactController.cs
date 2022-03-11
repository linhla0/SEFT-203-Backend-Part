using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;
        private ILogger<TaskController> _logger;

        public ContactsController(IContactService service, IMapper mapper, ILogger<TaskController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string keyword)
        {
            var contacts = _service.GetAll(keyword);
            var model = _mapper.Map<IList<Contact>>(contacts);
            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var contact = _service.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Contact>(contact);
            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Contact model)
        {
            var contact = _service.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            var savedContact = _service.Update(id, model);
            return Ok(savedContact);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Contact model)
        {
            var createdContact = _service.Create(model);
            return Ok(createdContact);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var contact = _service.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            var deletedContact = _service.Delete(id);
            return Ok(deletedContact);
        }
    }
}
