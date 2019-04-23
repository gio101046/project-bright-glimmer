using System.Threading.Tasks;
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
            if (students == null)
            {
                return NotFound();
            }

            return new JsonResult(students);
        }
    }
}