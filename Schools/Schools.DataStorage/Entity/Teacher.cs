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
    public class Teacher :User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long TeacherSSN { get; set; }

        // RelationShip between Teacher And Subject
        public virtual ICollection<Subject> Subject { get; set; }
        public virtual TeacherAdress TeacherAdress { get; set; }

        // RelationShip between Teacher And ApplicationUser
        public string User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Teacherabsence> Teacherabsences { get; set; }


    }
}
