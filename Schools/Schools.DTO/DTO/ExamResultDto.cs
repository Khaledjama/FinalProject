using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class ExamResultDto
    {
        [Required(ErrorMessage ="You Shoud Select Student")]
        public long StudentSSN { get; set; }
        [JsonIgnore]
        public virtual StudentDto Student { get; set; }
        [Required(ErrorMessage = "You Shoud Select Subject")]
        public string SubjectId { get; set; }
        [JsonIgnore]
        public virtual SubjectDto Subject { get; set; }
        [Required(ErrorMessage = "You Shoud Select Exam")]
        public int ExamId { get; set; }
        [JsonIgnore]
        public virtual ExamDto Exam { get; set; }
        [Required(ErrorMessage = "You Shoud Put Exam Degree")]
        public double ExamDegree { get; set; }

    }
}
