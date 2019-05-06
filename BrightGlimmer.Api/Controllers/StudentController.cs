using System;
using System.Threading.Tasks;
using BrightGlimmer.Service.Commands;
using BrightGlimmer.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrightGlimmer.Api.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Get()
        {
            var students = await mediator.Send(new GetStudentsQuery());
            return new JsonResult(students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var student = await mediator.Send(new GetStudentQuery(id));
            return new JsonResult(student);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateStudentCommand command)
        {
            var student = await mediator.Send(command);
            return new JsonResult(student);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]UpdateStudentCommand command)
        {
            var student = await mediator.Send(command);
            return new JsonResult(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await mediator.Send(new DeleteStudentCommand(id));
            return new JsonResult(success);
        }
    }
}