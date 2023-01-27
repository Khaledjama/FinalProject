using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DataBase.Context
{
    public class SchoolsDB :IdentityDbContext<ApplicationUser>
    {
        public SchoolsDB(DbContextOptions<SchoolsDB> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relationship between Teacher and Subjects Tables

            builder.Entity<Subject>().HasKey(s => s.CodeId);

            builder.Entity<Subject>()
                .HasOne<Teacher>(s => s.Teacher)
                .WithMany(s => s.Subject).HasForeignKey(s => s.TeacherId);

            // Relationship between Teacher and TeacherAdress Tables
            builder.Entity<TeacherAdress>().HasKey(s => s.TeacherSSN);

            builder.Entity<Teacher>()
                .HasOne<TeacherAdress>(s => s.TeacherAdress)
                .WithOne(s => s.Teacher).HasForeignKey<TeacherAdress>(s => s.TeacherSSN);


            // Relationship between Student and StudentAdress Tables
            builder.Entity<StudentAdress>().HasKey(s => s.StudentSSN);

            builder.Entity<Student>()
                .HasOne<StudentAdress>(s => s.StudentAdress)
                .WithOne(s => s.Student).HasForeignKey<StudentAdress>(s => s.StudentSSN);


            // RelationSipt between Techer and ApplicatioUser

            builder.Entity<Teacher>()
                .HasOne<ApplicationUser>(s => s.ApplicationUser)
                .WithOne(s => s.Teacher).HasForeignKey<Teacher>(s => s.User_Id);

            // RelationSipt between Student and ApplicatioUser

            builder.Entity<Student>()
                .HasOne<ApplicationUser>(s => s.ApplicationUser)
                .WithOne(s => s.Student).HasForeignKey<Student>(s => s.User_Id);

            // --------------- Start -----------------------
            // Many To Many  RelationSipt between Student and Subject
            // Composed Key { StudentId, SubjectId}
            builder.Entity<StudentsSubjects>()
                .HasKey(c => new { c.StudentId, c.SubjectId });

            // configration RelationSipt between StudentsSubjects and Student

            builder.Entity<StudentsSubjects>()
                .HasOne(s => s.Student)
                .WithMany(s => s.StudentsSubjects)
                .HasForeignKey(s => s.StudentId);
            // configration RelationSipt between StudentsSubjects and Subject

            builder.Entity<StudentsSubjects>()
                .HasOne(s => s.Subject)
                .WithMany(s => s.StudentsSubjects)
                .HasForeignKey(s => s.SubjectId);

            // configration RelationSipt between Student and Parent

            builder.Entity<Student>()
                .HasOne<Parent>(s => s.Parent)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.ParentId);


            // RelationSipt between Student and ApplicatioUser
            builder.Entity<Parent>()
                .HasOne<ApplicationUser>(s => s.ApplicationUser)
                .WithOne(s => s.Parent).HasForeignKey<Parent>(s => s.User_Id);
            // ------------------- End ----------------------
            base.OnModelCreating(builder);

        }
        public DbSet<Test> Test { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAdress> TeacherAdresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentsSubjects> StudentsSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
