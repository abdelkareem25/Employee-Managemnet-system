using AutoMapper;
using EmpMangSys.Api.DTOs.Employees;
using EmpMangSys.Core.Data;
using EmpMangSys.Core.Interface;
using EmpMangSys.Repository.DataBaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpMangSys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeesRepository repository;

        public EmployeeController(IMapper mapper ,IEmployeesRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        //Get all
        [HttpGet]
        public ActionResult<IEnumerable<GetEmployeesDTOs>> GetAll()
        {
            try
            {
                var result = repository.GetAll();
                if (result == null || !result.Any())
                {
                    return NotFound(new { message = "No employees found"});
                }
                var map= mapper.Map<IEnumerable<GetEmployeesDTOs>>(result);
                return Ok(map);
            }
            catch (Exception)
            {
                var errorMessage = new
                {
                    message = $"An error occurred while retrieving employees"
                };
                return StatusCode(500, errorMessage);
            }
            
        }
        //Get by id
        [HttpGet("{id}")]
        public ActionResult<GetEmployeesDTOs> GetById(int id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                var map = mapper.Map<GetEmployeesDTOs>(result);
                return Ok(map);
            }
            catch (Exception)
            {

                var errorMessage = new
                {
                    message = $"No employee here have that ID"
                };
                return StatusCode(400, errorMessage);
            }
            
        }
        //Create
        [HttpPost]
        public ActionResult Create(CreateEmployeeDTOs createEmployeeDto)
        {
            var employee = mapper.Map<Employee>(createEmployeeDto);
            repository.Create(employee);
            
            return Ok(mapper.Map<GetEmployeesDTOs>(employee)); // Return the created employee with its new ID [Chat GPT help me here]
        }
        //Update
        [HttpPut("{id}")]
        public ActionResult Update(GetEmployeesDTOs dto ,int id)
        {
            //var employee = mapper.Map<Employee>(dto);  // my code
            //repository.Update(employee);
            //return Ok(employee);

            var existingEmployee = repository.GetById(id); // chat gpt code
            if (existingEmployee == null)
            {
                return NotFound();
            }
            mapper.Map(dto, existingEmployee);
            repository.Update(existingEmployee);
            return Ok(existingEmployee);
        }
        //Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok();
        }

        // Search Endpoint
        [HttpGet("search")]
        public ActionResult Search(string name , string department)
        {
            var result = repository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(e => e.FullName == name).ToList();
            if(!string.IsNullOrEmpty(department))
                result = result.Where(e => e.Department.Name == department);
            return Ok(result);
        }
    }
}
