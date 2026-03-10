using EmpMangSys.Core.Data;

namespace EmpMangSys.Api.DTOs.Employees
{
    public class GetEmployeesDTOs
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentName { get; set; }
    }
}
