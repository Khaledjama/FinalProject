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
    public class Parent : User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long ParentSSN { get; set; }

        public virtual ICollection<Student> Students { get; set; }


        // RelationShip between Parent And ApplicationUser
        public string User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
