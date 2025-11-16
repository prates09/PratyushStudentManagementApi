using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Data
{
    // Simple in–memory store – data is lost when app stops
    public class InMemoryStudentData : IStudentData
    {
        private readonly List<Student> _studentRecords = new();
        private int _nextStudentId = 1;
        private readonly object _lockObject = new();

        public InMemoryStudentData()
        {
            
        }

        public Task<List<Student>> GetAllAsync()
        {
            lock (_lockObject)
            {
                return Task.FromResult(_studentRecords.ToList()); // return a copy of the list
            }
        }

        public Task<Student?> GetByIdAsync(int studentId)
        {
            lock (_lockObject)
            {
                var match = _studentRecords
                    .FirstOrDefault(s => s.StudentId == studentId);
                return Task.FromResult(match);
            }
        }

        public Task<Student> AddAsync(Student newStudent)
        {
            if (newStudent is null)
                throw new ArgumentNullException(nameof(newStudent));

            lock (_lockObject)
            {
                newStudent.StudentId = _nextStudentId++;
                _studentRecords.Add(newStudent);
                return Task.FromResult(newStudent);
            }
        }

        public Task<bool> UpdateAsync(Student updatedStudent)
        {
            if (updatedStudent is null)
                throw new ArgumentNullException(nameof(updatedStudent));

            lock (_lockObject)
            {
                var existing = _studentRecords
                    .FirstOrDefault(s => s.StudentId == updatedStudent.StudentId);

                if (existing is null)
                    return Task.FromResult(false);

                existing.FullName = updatedStudent.FullName;
                existing.Age = updatedStudent.Age;
                existing.EmailAddress = updatedStudent.EmailAddress;
                existing.EnrollmentYear = updatedStudent.EnrollmentYear;

                return Task.FromResult(true);
            }
        }

        public Task<bool> DeleteAsync(int studentId)
        {
            lock (_lockObject)
            {
                var existing = _studentRecords
                    .FirstOrDefault(s => s.StudentId == studentId);

                if (existing is null)
                    return Task.FromResult(false);

                _studentRecords.Remove(existing);
                return Task.FromResult(true);
            }
        }
    }
}
