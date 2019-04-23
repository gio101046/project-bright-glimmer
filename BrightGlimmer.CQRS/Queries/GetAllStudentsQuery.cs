using BrightGlimmer.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Services.Queries
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
