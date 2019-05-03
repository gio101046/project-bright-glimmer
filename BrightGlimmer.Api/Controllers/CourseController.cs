using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BrightGlimmer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator mediator;

        public CourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return new JsonResult("");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return new JsonResult("");
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]object command)
        { 
            return new JsonResult("");
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]object command)
        {
            return new JsonResult("");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return new JsonResult("");
        }
    }
}
