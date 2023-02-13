using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Schools.DTO.DTO
{
    public class ExamTypeDto
    {
        public int? Id { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }

        //[JsonIgnore]
        public virtual ICollection<ExamDto> Exam { get; set; }

    }
}
