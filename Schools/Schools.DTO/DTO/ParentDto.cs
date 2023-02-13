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
    public class ParentDto
    {
        [Required(ErrorMessage ="Please enter SSN for Parent")]
        public long? ParentSSN { get; set; }
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
        public IFormFile Picture { get; set; }
        public string Image { get; set; }
        //[JsonIgnore]
        public virtual ICollection<StudentDto> Students { get; set; }


        // RelationShip between Parent And ApplicationUser
        //[JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
