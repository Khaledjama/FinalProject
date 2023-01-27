using Schools.DAL.Interfacies.GenaricInterface;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.Interfacies.NonGenaricInterface
{
    interface IStudentReprositry : IGenaricReprositry<Student>
    {
        //string UploadImage(string OldPicture ,)
    }
}
