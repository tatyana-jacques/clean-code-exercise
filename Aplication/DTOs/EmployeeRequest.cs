
namespace Aplication.DTOs
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public int PermissionId { get; set; }
    }
}
