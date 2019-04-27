using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using BrightGlimmer.Service.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BrightGlimmer.Service.Handlers.QueryHandlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly IQueryRepository<Student> repository;

        public GetStudentsQueryHandler(IQueryRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await repository.Get().ToListAsync();
        }
    }
}
