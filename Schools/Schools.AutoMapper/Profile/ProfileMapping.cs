using AutoMapper;
using Schools.DataStorage.Entity;
using Schools.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.AutoMapper.ProfileMapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

            CreateMap<Parent, ParentDto>();
            CreateMap<ParentDto, Parent>();

            CreateMap<TeacherAdress, TeacherAdressDto>();
            CreateMap<TeacherAdressDto, TeacherAdress>();

            CreateMap<SubjectDto, Subject>();
            CreateMap<Subject, SubjectDto>();

            CreateMap<StudentAdress, StudentAdressDto>();
            CreateMap<StudentAdressDto, StudentAdress>();

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<StudentsSubjects, StudentSubjectDTO>();
            CreateMap<StudentSubjectDTO, StudentsSubjects>();

            CreateMap<Studentabsence, StudentAbsenceDto>();
            CreateMap<StudentAbsenceDto, Studentabsence>();

            CreateMap<Teacherabsence, TeacherAbsenceDto>();
            CreateMap<TeacherAbsenceDto, Teacherabsence>();

            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();

            CreateMap<ExamType, ExamTypeDto>();
            CreateMap<ExamTypeDto, ExamType>();

            CreateMap<ExamAnswer, ExamAnswerDto>();
            CreateMap<ExamAnswerDto, ExamAnswer>();

            CreateMap<ExamResult, ExamResultDto>();
            CreateMap<ExamResultDto, ExamResult>();

            CreateMap<ClassRoom, ClassRoomDto>();
            CreateMap<ClassRoomDto, ClassRoom>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<SchoolYears, SchoolYearsDto>();
            CreateMap<SchoolYearsDto, SchoolYears>();


        }
    }
}
