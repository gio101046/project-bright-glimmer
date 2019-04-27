using BrightGlimmer.Data.Interfaces;
using BrightGlimmer.Domain;
using BrightGlimmer.Service.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BrightGlimmer.Service.Handlers.QueryHandlers
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, Student>
    {
        private readonly IQueryRepository<Student> repository;

        public GetStudentQueryHandler(IQueryRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<Student> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(request.Id);
        }
    }
}
