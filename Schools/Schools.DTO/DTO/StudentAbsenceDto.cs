using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class StudentAbsenceDto
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public long? StudentSSN { get; set; }
        //[JsonIgnore]
        public virtual StudentDto Student { get; set; }

    }
}
