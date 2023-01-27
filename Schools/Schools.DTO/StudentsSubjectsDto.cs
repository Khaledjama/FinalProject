using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DTO
{
    public class StudentsSubjectsDto
    {
        public string SubjectId { get; set; }
        //public Subject Subject { get; set; }
        public long StudentId { get; set; }
        //public Student Student { get; set; }

        public string Description { get; set; }
    }
}
