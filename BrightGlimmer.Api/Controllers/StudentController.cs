using System.Threading.Tasks;
using BrightGlimmer.Service.Commands;
using BrightGlimmer.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrightGlimmer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var students = await mediator.Send(new GetAllStudentsQuery());
            return new JsonResult(students);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateStudentCommand command)
        {
            var student = await mediator.Send(command);
            return new JsonResult(student);
        }
    }
}