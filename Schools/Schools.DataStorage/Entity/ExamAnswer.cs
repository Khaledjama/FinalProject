using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class ExamAnswer
    {
        public int Id { get; set; }
        public string ExamAnswerType { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
