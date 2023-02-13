using Schools.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class EmployeeDto:User
    {
        public long EmployeeSSN { get; set; }

        public int DepartmentId { get; set; }
        //[JsonIgnore]
        public virtual DepartmentDto Department { get; set; }
    }
}
