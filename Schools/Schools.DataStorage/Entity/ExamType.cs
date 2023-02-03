using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class ExamType
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
