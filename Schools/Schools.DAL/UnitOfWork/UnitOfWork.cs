using Schools.DAL.Interfacies.GenaricInterface;
using Schools.DAL.Interfacies.NonGenaricInterface;
using Schools.DAL.Reprositries.GenaricReprositry;
using Schools.DAL.Reprositries.NonGenaricReprositry;
using Schools.DataBase.Context;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.UnitOfWork
{
   public class UnitOfWork :IUnitOfWork
    {
        private readonly SchoolsDB _Context;
        public IGenaricReprositry<Test> Tests { get; private set; }

        public ITestReprositry TestRepo { get; private set; }
        public IUserReprositry UserRepo { get; private set; }

        public IGenaricReprositry<Teacher> Teacher { get; private set; }

        public IGenaricReprositry<TeacherAdress> TeacherAdress { get; private set; }

        public IGenaricReprositry<Subject> Subject { get; private set; }

        public IGenaricReprositry<Student> Student { get; private set; }

        public IGenaricReprositry<StudentAdress> StudentAdress { get; private set; }

        public IGenaricReprositry<StudentsSubjects> StudentSubject { get; private set; }

        public IGenaricReprositry<Parent> Parent { get; private set; }

        public IGenaricReprositry<Studentabsence> StudentAbsence { get; private set; }

        public IGenaricReprositry<Teacherabsence> TeacherAbsence { get; private set; }

        public IGenaricReprositry<Department> Department { get; private set; }

        public IGenaricReprositry<Employee> Employee { get; private set; }

        public IGenaricReprositry<Exam> Exam { get; private set; }

        public IGenaricReprositry<ExamType> ExamType { get; private set; }

        public IGenaricReprositry<ExamAnswer> ExamAnswer { get; private set; }

        public IGenaricReprositry<ExamResult> ExamResult { get; private set; }

        public IExamResultReprositry ExamResultRepo { get; private set; }

        public IGenaricReprositry<SchoolYears> SchoolsYears { get; private set; }

        public IGenaricReprositry<ClassRoom> ClassRoom { get; private set; }


        //public IGenaricReprositry<StudentAdress> StudentAdresses { get; private set; }

        //public IGenaricReprositry<Teacher> Teachers { get; private set; }

        //public IGenaricReprositry<Course> Courses { get; private set; }

        //public IGenaricReprositry<Exam> Exams { get; private set; }

        public UnitOfWork(SchoolsDB Context)
        {
            _Context = Context;
            Tests = new GenaricReprositry<Test>(_Context);
            Teacher = new GenaricReprositry<Teacher>(_Context);
            Parent = new GenaricReprositry<Parent>(_Context);
            TeacherAdress = new GenaricReprositry<TeacherAdress>(_Context);
            Subject = new GenaricReprositry<Subject>(_Context);
            Student = new GenaricReprositry<Student>(_Context);
            StudentAdress = new GenaricReprositry<StudentAdress>(_Context);
            StudentSubject = new GenaricReprositry<StudentsSubjects>(_Context);
            StudentAbsence = new GenaricReprositry<Studentabsence>(_Context);
            TeacherAbsence = new GenaricReprositry<Teacherabsence>(_Context);
            Department = new GenaricReprositry<Department>(_Context);
            Employee = new GenaricReprositry<Employee>(_Context);
            Exam = new GenaricReprositry<Exam>(_Context);
            ExamType = new GenaricReprositry<ExamType>(_Context);
            ExamAnswer = new GenaricReprositry<ExamAnswer>(_Context);
            ExamResult = new GenaricReprositry<ExamResult>(_Context);
            ClassRoom = new GenaricReprositry<ClassRoom>(_Context);
            SchoolsYears = new GenaricReprositry<SchoolYears>(_Context);
            //Exams = new GenaricReprositry<Exam>(_Context);
            TestRepo = new TestReprositry(_Context);
            UserRepo = new UserReprositry(_Context);
            ExamResultRepo = new ExamResultReprositry(_Context);
        }

        public int Complete()
        {
            return _Context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
