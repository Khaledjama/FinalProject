using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class TeacherDto
    {
        [Required(ErrorMessage ="Please insert Your SSN")]
        public long TeacherSSN { get; set; }
        [Required(ErrorMessage ="Plaese enter First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Plaese enter Middle Name ")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Plaese enter Last Name ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Plaese insert Data of Birthday "),DataType(DataType.Date)]
        public DateTime DB { get; set; }
        [MaxLength(11,ErrorMessage ="Please insert 11 numbers")]
        [MinLength(11,ErrorMessage ="Please insert 11 numbers")]
        public string Phone { get; set; }
        // it can null when Admin Add information yo teacher
        public string User_Id { get; set; }
        public IFormFile Picture { get; set; }
        public string Image { get; set; }
    }
}
