using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class SchoolYearsDto
    {
        public int Id { get; set; }
        public string SchoolYear { get; set; }
        //[JsonIgnore]
        public virtual ICollection<StudentDto> Students { get; set; }
        //[JsonIgnore]
        public virtual ICollection<ExamDto> Exams { get; set; }
    }
}
