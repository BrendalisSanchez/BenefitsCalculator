using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Domain.Employees
{
    public class Employees
    {
        public int Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Dependents { get; set; }
        public int Paycheck { get; set; }
        public string Status { get; set; }       

    }
}
