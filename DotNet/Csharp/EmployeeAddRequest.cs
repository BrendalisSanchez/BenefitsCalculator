using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Requests.Employees
{
    public class EmployeesAddRequest
    {

        [Required]
        [Range(1, 90000)]
        public int EmployeeNumber { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2)]
        public string FirstName { get; set; }        
        [StringLength(100, MinimumLength = 2)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [Range(1, 90000)]
        public int Dependents { get; set; }
        [Range(1, 90000)]
        public int Paycheck { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Status { get; set; }

    }

}
