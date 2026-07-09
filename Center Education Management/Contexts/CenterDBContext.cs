using Center_Education_Management.Models;
using Center_Education_Management.view_models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.EFcore
{
    public class CenterDBContext : DbContext
    {
        public CenterDBContext(DbContextOptions<CenterDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
                optionsBuilder.UseLazyLoadingProxies(true);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CenterDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AcademicSeason> AcademicSeasons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<CenterAdmin> CenterAdmins { get; set; }
        public DbSet<CenterOwner> Centerowners { get; set; }
        public DbSet<Centerrequest> Centerrequests { get; set; }
        public DbSet<Centersubscription> Centersubscriptions { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<EducationalStage> EducationalStages { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamAnswer> ExamAnswers { get; set; }
        public DbSet<ExamAttempt> ExamAttempts { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ManualGrade> ManualGrades { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Paymentgetway> Paymentgetways { get; set; }
        public DbSet<QRToken> QRTokens { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLead> StudentLeads { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Superadmin> Superadmins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAssistant> Assistants { get; set; }
        public DbSet<TeacherEducationalStage> TeacherEducationalStages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}