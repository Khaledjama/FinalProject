using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class StudentSubjectDTO
    {
        public string SubjectId { get; set; }
        //[JsonIgnore]
        public virtual SubjectDto Subject { get; set; }
        public long StudentId { get; set; }
        //[JsonIgnore]
        public virtual StudentDto Student { get; set; }
        public string Description { get; set; }
    }
}
