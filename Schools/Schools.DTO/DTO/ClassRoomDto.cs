using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class ClassRoomDto
    {
        public int Id { get; set; }
        public int ClassRoomNumber { get; set; }
        //[JsonIgnore]
        public virtual ICollection<StudentDto> Students { get; set; }
    }
}
