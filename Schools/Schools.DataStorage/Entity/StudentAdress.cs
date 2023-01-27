using Schools.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class StudentAdress : UserAdress
    {
        public long StudentSSN { get; set; }

        public virtual Student Student { get; set; }
    }
}
