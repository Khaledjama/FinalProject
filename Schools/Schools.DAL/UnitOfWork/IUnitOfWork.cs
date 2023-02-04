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
        IExamResultReprositry ExamResultRepo { get; }
        IGenaricReprositry<Studentabsence> StudentAbsence { get; }
        IGenaricReprositry<Teacherabsence> TeacherAbsence { get; }
        IGenaricReprositry<Department> Department { get; }
        IGenaricReprositry<Employee> Employee { get; }

        IGenaricReprositry<Exam> Exam { get; }
        IGenaricReprositry<ExamType> ExamType { get; }
        IGenaricReprositry<ExamAnswer> ExamAnswer { get; }
        IGenaricReprositry<ExamResult> ExamResult { get; }
        IGenaricReprositry<SchoolYears> SchoolsYears { get; }
        IGenaricReprositry<ClassRoom> ClassRoom { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
