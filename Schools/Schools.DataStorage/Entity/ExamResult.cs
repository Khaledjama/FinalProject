using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
   public class ExamResult
    {
        public long StudentSSN { get; set; }
        public virtual Student Student { get; set; }


        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public double ExamDegree { get; set; }
        
    }
}
