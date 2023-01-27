using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
   public class LoginDto
    {
        [Required(ErrorMessage ="Please insert Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please insert Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
