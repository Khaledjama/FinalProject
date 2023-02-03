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
    public class TestReprositry : GenaricReprositry<Test>, ITestReprositry
    {
        private readonly SchoolsDB DB;
        public TestReprositry(SchoolsDB Db) : base(Db)
        {
            this.DB = Db;
        }
        public IEnumerable<Test> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
