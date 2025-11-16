using MediatR;
using PratyushStudentManagementApi.Data;
using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Handlers.Commands
{
    // Command to add a new student
    public record AddStudentCommand(
        string FullName,
        int Age,
        string EmailAddress,
        int EnrollmentYear) : IRequest<Student>;

    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IStudentData _studentDataStore; // Dependency injection of the data store

        public AddStudentCommandHandler(IStudentData studentDataStore)
        {
            _studentDataStore = studentDataStore; // Initialize the data store
        }

        // Handle method to process the addition of a new student
        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var newStudent = new Student
            {
                FullName = request.FullName,
                Age = request.Age,
                EmailAddress = request.EmailAddress,
                EnrollmentYear = request.EnrollmentYear
            };

            var savedStudent = await _studentDataStore.AddAsync(newStudent); // Save the new student to the data store
            return savedStudent;
        }
    }
}
