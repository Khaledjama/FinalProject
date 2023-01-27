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

        }
    }
}
