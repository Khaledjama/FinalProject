using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataStorage.Entity
{
    public class ApplicationUser :IdentityUser
    {
        public string Comment { get; set; }



        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
        public virtual Parent  Parent { get; set; }
    }
}
