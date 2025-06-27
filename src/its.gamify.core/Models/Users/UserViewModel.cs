using its.gamify.core.Models.Departments;
using its.gamify.domains.Entities;

namespace its.gamify.core.Models.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string DeptName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string MetricDescription { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; } = new();

    }
}
