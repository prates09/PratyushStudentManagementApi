using MediatR;
using PratyushStudentManagementApi.Data;
using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Handlers.Queries
{
    public record GetStudentByIdQuery(int StudentId) : IRequest<Student?>;

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student?>
    {
        private readonly IStudentData _studentDataStore;

        public GetStudentByIdQueryHandler(IStudentData studentDataStore)
        {
            _studentDataStore = studentDataStore;
        }

        public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentDataStore.GetByIdAsync(request.StudentId);
            return student;
        }
    }
}
