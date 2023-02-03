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


        // Relationship between Student And StudentAbsense
        public virtual ICollection<Studentabsence> Studentabsences { get; set; }

        // Relationship between Student And SchoolYears
        public int SchoolsYearId { get; set; }
        public virtual SchoolYears SchoolYears { get; set; }
        // Relationship between Student And ClassRoom
        public int ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public virtual ICollection<ExamResult> ExamResult { get; set; }



    }
}
