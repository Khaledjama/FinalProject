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
    public class Student : User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long StudenntSSN { get; set; }

        // RelationShip between Teacher And Subject
        public virtual StudentAdress StudentAdress { get; set; }

        // RelationShip between Teacher And ApplicationUser
        public string User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        // RelationShip between Student And Subjects

        public virtual ICollection<StudentsSubjects> StudentsSubjects { get; set; }

        // RelationShip between Student And Parents
        public long? ParentId { get; set; }
        public virtual Parent Parent { get; set; }



    }
}
