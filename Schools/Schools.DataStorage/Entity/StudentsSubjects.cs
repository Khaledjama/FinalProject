using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class StudentsSubjects
    {
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string Description { get; set; }


    }
}
