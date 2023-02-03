using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class Exam
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Plaese enter First Name ")]
        public string ExamName { get; set; }
        
        public string? ExamPdf { get; set; }
        public string? ExamLink { get; set; }
        [Required(ErrorMessage = "Plaese enter Start DateTime Exam")]
        public DateTime StartAt { get; set; }
        [Required(ErrorMessage = "Plaese enter End DateTime Exam")]
        public DateTime EndAt { get; set; }
        [Required(ErrorMessage = "Plaese enter Type Of Exam Exam")]
        public int ExamTypeId { get; set; }
        public virtual ExamType ExamType { get; set; }
        [Required(ErrorMessage = "Plaese enter Answer Of Exam Exam")]
        public int ExamAnswerId { get; set; }
        public virtual ExamAnswer ExamAnswer { get; set; }

        [Required(ErrorMessage = "Plaese enter exam for SchoolYears")]
        public int SchoolYearsId { get; set; }
        public virtual SchoolYears SchoolYears { get; set; }

        public double FinalDegree { get; set; }
        

        public virtual ICollection<ExamResult> ExamResult { get; set; }

    }
}
