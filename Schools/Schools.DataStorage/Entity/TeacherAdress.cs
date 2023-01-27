using Schools.Service.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
   public class TeacherAdress : UserAdress
    {
        
        public long TeacherSSN { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
