using Schools.DAL.Interfacies.NonGenaricInterface;
using Schools.DAL.Reprositries.GenaricReprositry;
using Schools.DataBase.Context;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.Reprositries.NonGenaricReprositry
{
    public class UserReprositry : GenaricReprositry<ApplicationUser>, IUserReprositry
    {
        private readonly SchoolsDB DB;
        public UserReprositry(SchoolsDB Db) : base(Db)
        {
            this.DB = Db;

        }
        public Student GetCurrentUserByUserId(string UserId)
        {
            var CurrentStudent = DB.Students.Where(s => s.User_Id == UserId).FirstOrDefault();
            return CurrentStudent;


        }
    }
}
