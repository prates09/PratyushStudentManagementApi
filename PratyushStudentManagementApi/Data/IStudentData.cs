using PratyushStudentManagementApi.Models;

namespace PratyushStudentManagementApi.Data
{
    // Interface defining CRUD operations for student data
    public interface IStudentData
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int studentId);
        Task<Student> AddAsync(Student newStudent);
        Task<bool> UpdateAsync(Student updatedStudent);
        Task<bool> DeleteAsync(int studentId);
    }
}
