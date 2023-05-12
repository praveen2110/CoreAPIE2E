using Employee.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employees>> GetEmployees();
        Task<Employees> GetEmployeeByID(int ID);
        Task<Employees> InsertEmployee(Employees objEmployee);
        Task<Employees> UpdateEmployee(Employees objEmployee);
        bool DeleteEmployee(int ID);
    }
}
