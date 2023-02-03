using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class Studentabsence
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long StudentSSN { get; set; }
        public virtual Student Student { get; set; }

    }
}
