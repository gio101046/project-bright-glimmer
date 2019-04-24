using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using BrightGlimmer.Services.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore; /* TODO */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BrightGlimmer.Services.Handlers.QueryHandlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly IQueryRepository<Student> repository;

        public GetAllStudentsQueryHandler(IQueryRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await repository.Get()
                                   .Include(x => x.Phones)
                                   .Include(x => x.Address)
                                   .Include(x => x.AssignedCourses)
                                   .ToListAsync();
        }
    }
}
