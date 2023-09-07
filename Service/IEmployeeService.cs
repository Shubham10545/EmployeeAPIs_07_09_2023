using Domain.Models;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Service
{
    public interface IEmployeeService
    {
        // Get All Records
        List<Domain.ViewModels.GetAllEmployeeData> GetEmployees();
       
        // Get Single 
       

        // Add Employee
        List<Employee> AddEmployee(EmployeeVM employee);
        // Update
        List<Employee> UpdateEmployee(UpdateEmployee employee);
        // Delete
        int DeleteEmployee(int id);

       
    }
}
