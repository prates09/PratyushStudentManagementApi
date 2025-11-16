using MediatR;
using PratyushStudentManagementApi.Data;
using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Handlers.Queries
{
    public record GetAllStudentsQuery : IRequest<List<Student>>; // Query to get all students

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentData _studentDataStore;

        public GetAllStudentsQueryHandler(IStudentData studentDataStore)
        {
            _studentDataStore = studentDataStore;
        }

        // Handle method to process the query and return all students
        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentDataStore.GetAllAsync();
            return students;
        }
    }
}
