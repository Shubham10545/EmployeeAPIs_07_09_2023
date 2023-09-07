using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        List<Domain.ViewModels.GetAllEmployeeData> GetEmployees();

        List<Employee> AddEmployee(Employee employee);

        List<Employee> UpdateEmployee(Employee employee);
        int DeleteEmployees(int id);
        string FileUploads(Employee employee);
       
    }
}
