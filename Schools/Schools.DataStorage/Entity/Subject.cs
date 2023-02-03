using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class Subject
    {
        
        public string CodeId { get; set; }
        public string Name { get; set; }
        public double  SubjectDuration { get; set; }

        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        // RelationShip between Subject And Students

        public virtual ICollection<StudentsSubjects> StudentsSubjects { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }

    }
}
