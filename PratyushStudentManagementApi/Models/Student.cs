namespace PratyushStudentManagementApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }                  // unique id in memory
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public int EnrollmentYear { get; set; }
    }
}
