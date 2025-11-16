using MediatR;
using PratyushStudentManagementApi.Data;
using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Handlers.Commands
{
    // for updating the student details
    public record UpdateStudentCommand(
        int StudentId,
        string FullName,
        int Age,
        string EmailAddress,
        int EnrollmentYear) : IRequest<bool>;

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentData _studentDataStore; // dependency injection of data store

        public UpdateStudentCommandHandler(IStudentData studentDataStore)
        {
            _studentDataStore = studentDataStore; // initialize data store
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            // create a student object with updated details
            var studentToUpdate = new Student
            {
                StudentId = request.StudentId,
                FullName = request.FullName,
                Age = request.Age,
                EmailAddress = request.EmailAddress,
                EnrollmentYear = request.EnrollmentYear
            };

            var updated = await _studentDataStore.UpdateAsync(studentToUpdate); // call data store to update student
            return updated;
        }
    }
}
