using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
   public class SubjectDto
    {
        [Required(ErrorMessage ="Please Insert Code of this Subject")]
        public string CodeId { get; set; }
        [Required(ErrorMessage = "Please Insert Name of this Subject")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please Insert Duration Time of this Subject")]
        public double SubjectDuration { get; set; }


        [Required(ErrorMessage = "Please Added Thid Subject to Any Teacher")]
        public long TeacherId { get; set; }
        //[JsonIgnore]
        public virtual TeacherDto Teacher { get; set; }

        // RelationShip between Subject And Students
        //[JsonIgnore]
        public virtual ICollection<StudentsSubjectsDto> StudentsSubjects { get; set; }
        //[JsonIgnore]
        public virtual ICollection<ExamResultDto> ExamResult { get; set; }
    }
}
