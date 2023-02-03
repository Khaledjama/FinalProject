using Schools.DAL.Interfacies.GenaricInterface;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.Interfacies.NonGenaricInterface
{
    public interface IExamResultReprositry : IGenaricReprositry<ExamResult>
    {
        ExamResult GetExamResult(long? StudentSS, string SubjectId, int? ExamId);
        bool       UpdateExamResult(long? StudentSS, string SubjectId, int? ExamId,double Degree);
        bool       DeleteExamResult(long? StudentSS, string SubjectId, int? ExamId);
    }
}
