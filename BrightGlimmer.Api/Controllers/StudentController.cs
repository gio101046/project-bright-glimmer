using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightGlimmer.Data.Repositories; /* REMOVE LATER */
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrightGlimmer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // private readonly IMediator mediator;
        private readonly SqliteStudentRepository studentRepository;

        public StudentController(SqliteStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = studentRepository.GetAll();
            if (customers == null)
            {
                return NotFound();
            }

            return new ObjectResult(customers);
        }

        [HttpGet("createstudent")]
        public IActionResult CreateStudent()
        {
            var created = studentRepository.Create(new Data.Domain.Student
            {
                Id = Guid.NewGuid(),
                FirstName = "Giovani",
                LastName = "Rodriguez",
                Email = "giovaniluisrodriguez@gmail.com",
                Phones = new List<Data.Domain.Phone>
                {
                    new Data.Domain.Phone
                    {
                        Id = Guid.NewGuid(),
                        AreaCode = 305,
                        Number = 8888888,
                        Type = Data.Domain.PhoneType.HOMEPHONE
                    }
                }
            });

            return new ObjectResult(created);
        }
    }
}