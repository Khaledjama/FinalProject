using Microsoft.EntityFrameworkCore;
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
    public class ExamResultReprositry : GenaricReprositry<ExamResult>, IExamResultReprositry
    {
        private readonly SchoolsDB DB;
        public ExamResultReprositry(SchoolsDB Db) : base(Db)
        {
            this.DB = Db;
        }

        public ExamResult GetExamResult(long? StudentSS, string SubjectId, int? ExamId)
        {
            if (!StudentSS.HasValue || string.IsNullOrEmpty(SubjectId) || !ExamId.HasValue)
                return null;
            var ExamResult = DB.ExamResult.Where(s => s.StudentSSN == StudentSS
                                                                         && s.SubjectId == SubjectId
                                                                         && s.ExamId == ExamId).FirstOrDefault();
            if (ExamResult is null)
                return null;
            return ExamResult;
        }

        public bool UpdateExamResult(long? StudentSS, string SubjectId, int? ExamId, double Degree)
        {
            var Data = GetExamResult(StudentSS, SubjectId, ExamId);
            var CurrentExam = DB.Exam.Find(ExamId);
            if (Data is null || CurrentExam.FinalDegree < Degree)
                return false;
            Data.ExamDegree = Degree;
            DB.ExamResult.Update(Data);
            return DB.SaveChanges() > 0 ? true:false;
        }

        public bool DeleteExamResult(long? StudentSS, string SubjectId, int? ExamId)
        {
            var Data = GetExamResult(StudentSS, SubjectId, ExamId);
            if (Data is null)
                return false;
            DB.ExamResult.Remove(Data);
            return DB.SaveChanges() > 0 ? true : false;
        }
    }
}
