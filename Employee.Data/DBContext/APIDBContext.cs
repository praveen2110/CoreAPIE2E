using Employee.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.DBContext
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) { }
        //options = "data source=(LocalDB)\\MSSQLLocalDB;initial catalog=Web_API_Demo;persist security info=True;"
        public DbSet<Department> Departments
        {
            get;
            set;
        }
        public DbSet<Employees> Employees
        {
            get;
            set;
        }
    }
}
