using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using BrightGlimmer.Services.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore; /* TODO */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrightGlimmer.Services.Handlers.QueryHandlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly IRepository<Student> repository;

        public GetAllStudentsQueryHandler(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await repository.Get().ToListAsync();
        }
    }
}
