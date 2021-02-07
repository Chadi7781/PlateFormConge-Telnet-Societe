using API_Test.Contracts;
using API_Test.Entities;
using API_Test.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Repository
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private readonly TelnetContext _context;

        public EmployeeRepository(TelnetContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() => _context.Employees.ToList();


        public Employee GetEmployeeById(int id) => _context.Employees.SingleOrDefault(o => o.Id.Equals(id));

        

        public Employee CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
            return employee;
        }
       
        public Employee UpdateEmployee(Employee dbemployee, Employee employee)
        {
            dbemployee.RemainingCongeSolde= employee.RemainingCongeSolde;
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return dbemployee;
        }



        public Employee UpdateEmployeeRemaining(Employee dbemployee, int RemainingCongeSolde)
        {
            dbemployee.RemainingCongeSolde = RemainingCongeSolde;
            return dbemployee;
        }

        public Employee GetEmployeeByLogin(string login, string password) => _context.Employees.SingleOrDefault(o => (o.Login.Equals(login)) && (o.Password.Equals(password)));



    }
}
