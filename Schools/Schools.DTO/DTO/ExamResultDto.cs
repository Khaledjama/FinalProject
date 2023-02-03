using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class ExamResultDto
    {
        [Required(ErrorMessage ="You Shoud Select Student")]
        public long StudentSSN { get; set; }
        [Required(ErrorMessage = "You Shoud Select Subject")]
        public string SubjectId { get; set; }
        [Required(ErrorMessage = "You Shoud Select Exam")]
        public int ExamId { get; set; }
        [Required(ErrorMessage = "You Shoud Put Exam Degree")]
        public double ExamDegree { get; set; }

    }
}
