using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class TeacherAdressDto
    {
        public long? TeacherSSN { get; set; }
        public string State { get; set; }
        public string Government { get; set; }
        public string street { get; set; }
        public string ZipCode { get; set; }
        //[JsonIgnore]
        public virtual TeacherDto Teacher { get; set; }

    }
}
