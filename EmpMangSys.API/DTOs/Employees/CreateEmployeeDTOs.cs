namespace EmpMangSys.Api.DTOs.Employees
{
    public class CreateEmployeeDTOs
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
