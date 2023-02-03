using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class Teacherabsence
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long TeacherSSN { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
