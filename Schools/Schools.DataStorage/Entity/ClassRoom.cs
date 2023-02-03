using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public int ClassRoomNumber { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
