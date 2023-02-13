using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class ExamDto
    {

        public int? Id { get; set; }
        [Required(ErrorMessage = "Plaese enter First Name ")]
        public string ExamName { get; set; }

        public string? ExamPdf { get; set; }
        public string? ExamLink { get; set; }
        [Required(ErrorMessage = "Plaese enter Start DateTime Exam")]
        public DateTime StartAt { get; set; }
        [Required(ErrorMessage = "Plaese enter End DateTime Exam")]
        public DateTime EndAt { get; set; }
        [Required(ErrorMessage = "Plaese enter Type Of Exam ")]
        public int ExamTypeId { get; set; }
        [Required(ErrorMessage = "Plaese enter  SchoolYears")]
        public int SchoolYearsId { get; set; }
        [Required(ErrorMessage = "Plaese enter Answer Of Exam")]
        public int ExamAnswerId { get; set; }
        [Required(ErrorMessage = "Plaese enter FinalDegree Exam")]
        public double FinalDegree { get; set; }
        public IFormFile? ExamPicture { get; set; }



        //[JsonIgnore]
        public virtual ExamTypeDto ExamType { get; set; }
        //[JsonIgnore]
        public virtual SchoolYearsDto SchoolYears { get; set; }
        //[JsonIgnore]
        public virtual ExamAnswerDto ExamAnswer { get; set; }
        






    }
}
