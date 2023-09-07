using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContect _dbContext;
        public Repository(AppDbContect dbContext)
        {
            this._dbContext = dbContext; ;
        }

        List<GetAllEmployeeData> IRepository.GetEmployees()
        {
            var result = (from E in this._dbContext.Employee
                          join C in this._dbContext.Country on E.CountryId equals C.Id
                          join S in this._dbContext.State on C.Id equals S.CountryId
                          join CP in this._dbContext.City on S.Id equals CP.StateId

                          select new GetAllEmployeeData
                          {
                              Id = E.Id,
                              FirstName = E.FirstName,
                              LastName = E.LastName,
                              Email = E.Email,
                              Gender = E.Gender,
                              MaritalStatus = E.MaritalStatus,
                              BirthDate = E.BirthDate,
                              Salary = E.Salary,
                              Address = E.Address,
                              ZipCode = E.ZipCode,
                              Hobbies = E.Hobbies,
                              Country = C.CountryName,
                              State = S.StateName,
                              City = CP.CityName,
                              Password = E.Password
                          }).ToList();


            return result;
        }

        List<Employee> IRepository.AddEmployee(Employee employee)
        {
            _dbContext.Employee.Add(employee);
            this._dbContext.SaveChanges();
            List<Employee> result = new List<Employee> { employee };
            return result;
        }

        public List<Employee> UpdateEmployee(Employee employee)
        {
            _dbContext.Update(employee);
            this._dbContext.SaveChanges();
            List<Employee> result = new List<Employee> { employee };
            return result;
        }

        int IRepository.DeleteEmployees(int id)
        {
            // Find the employee by id
            var employeeToDelete = _dbContext.Employee.Find(id);

            if (employeeToDelete != null)
            {
                // Remove the employee entity from the DbSet
                _dbContext.Employee.Remove(employeeToDelete);

                // Save changes to the database
                _dbContext.SaveChanges();
            }

            return id;
        }

        string IRepository.FileUploads(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> AddEmployee(EmployeeVM employee)
        {
            throw new NotImplementedException();
        }
    }
    
}