using Microsoft.AspNetCore.Http;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
   public class StudentDto
    {
        //[Required(ErrorMessage = "Please insert Your SSN")]
        public long? StudenntSSN { get; set; }

        [Required(ErrorMessage = "Plaese enter First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Plaese enter Middle Name ")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Plaese enter Last Name ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Plaese insert Data of Birthday "), DataType(DataType.Date)]
        public DateTime DB { get; set; }
        [MaxLength(11, ErrorMessage = "Please insert 11 numbers")]
        [MinLength(11, ErrorMessage = "Please insert 11 numbers")]
        public string Phone { get; set; }
        // it can null when Admin Add information yo teacher
        public string User_Id { get; set; }

        public IFormFile Picture { get; set; }
        public string Image { get; set; }

        public int SchoolsYearId { get; set; }
        public int ClassRoomId { get; set; }



        // RelationShip between Teacher And Subject
        //[JsonIgnore]
        public virtual StudentAdressDto StudentAdress { get; set; }

        // RelationShip between Teacher And ApplicationUser
        //[JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }

        // RelationShip between Student And Subjects
        //[JsonIgnore]
        public virtual ICollection<StudentsSubjectsDto> StudentsSubjects { get; set; }

        // RelationShip between Student And Parents
        //[JsonIgnore]
        public virtual ParentDto Parent { get; set; }


        // Relationship between Student And StudentAbsense
        //[JsonIgnore]
        public virtual ICollection<StudentAbsenceDto> Studentabsences { get; set; }

        // Relationship between Student And SchoolYears
        //[JsonIgnore]
        public virtual SchoolYearsDto SchoolYears { get; set; }
        // Relationship between Student And ClassRoom
        //[JsonIgnore]
        public virtual ClassRoomDto ClassRoom { get; set; }
        //[JsonIgnore]
        public virtual ICollection<ExamResultDto> ExamResult { get; set; }

    }
}
