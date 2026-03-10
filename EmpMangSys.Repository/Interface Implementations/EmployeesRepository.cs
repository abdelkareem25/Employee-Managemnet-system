using EmpMangSys.Core.Interface;
using EmpMangSys.Repository.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMangSys.Repository.Interface_Implementations
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly BadrGroupDbContext context;

        public EmployeesRepository(BadrGroupDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            var result = context.Employees.Include(e => e.Department).ToList();
            return result;
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }
        public void Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
        }
    }
}
