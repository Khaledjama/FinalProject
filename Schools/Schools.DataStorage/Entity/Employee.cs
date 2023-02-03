using Schools.Service.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class Employee : User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeSSN { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


    }
}
