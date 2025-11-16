using MediatR;
using PratyushStudentManagementApi.Data;

namespace PratyushStudentManagementApi.Handlers.Commands
{
    public record DeleteStudentCommand(int StudentId) : IRequest<bool>; // Command to delete a student by ID
    // Command handler to process the deletion of a student
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentData _studentDataStore; // Dependency injection of the data store

        public DeleteStudentCommandHandler(IStudentData studentDataStore)
        {
            _studentDataStore = studentDataStore; // Initialize the data store
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var removed = await _studentDataStore.DeleteAsync(request.StudentId); // Call data store to delete the student
            return removed;
        }
    }
}
