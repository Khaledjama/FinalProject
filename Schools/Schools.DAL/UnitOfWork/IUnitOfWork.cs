using Schools.DAL.Interfacies.GenaricInterface;
using Schools.DAL.Interfacies.NonGenaricInterface;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IGenaricReprositry<Test> Tests { get; }
        IGenaricReprositry<Teacher> Teacher { get; }
        IGenaricReprositry<Parent> Parent { get; }
        IGenaricReprositry<TeacherAdress> TeacherAdress { get; }
        IGenaricReprositry<Subject> Subject { get; }
        IGenaricReprositry<Student> Student { get; }
        IGenaricReprositry<StudentAdress> StudentAdress { get; }
        IGenaricReprositry<StudentsSubjects> StudentSubject{ get; }
        //IGenaricReprositry<Exam> Exams { get; }
        //IStudentReprositry StudentRepo { get; }
        ITestReprositry TestRepo { get; }
        IUserReprositry UserRepo { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
