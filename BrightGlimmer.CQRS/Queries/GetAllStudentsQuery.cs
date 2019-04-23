using BrightGlimmer.Domain;
using MediatR;
using System.Collections.Generic;

namespace BrightGlimmer.Services.Queries
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
