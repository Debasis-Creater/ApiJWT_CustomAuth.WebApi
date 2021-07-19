using System;
using System.Collections.Generic;

namespace ApiJWT_CustomAuth.WebApi.Models
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeeAddress = new HashSet<EmployeeAddress>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<EmployeeAddress> EmployeeAddress { get; set; }
    }
}
