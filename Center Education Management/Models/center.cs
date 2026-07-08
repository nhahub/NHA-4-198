using Center_Education_Management.Models;
using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Center
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public virtual CenterOwner? Owner { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public CenterStatus Status { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public int? VerifiedBy { get; set; }
        public virtual Superadmin? VerifiedByAdmin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<Student> Students { get; set; }
            = new List<Student>();
        public virtual ICollection<Teacher> Teachers { get; set; }
            = new List<Teacher>();
        public virtual ICollection<Group> Groups { get; set; }
            = new List<Group>();
        public virtual ICollection<AcademicSeason> AcademicSeasons { get; set; }    
            = new List<AcademicSeason>();
        public virtual ICollection<Session> Sessions { get; set; }
            = new List<Session>();
        public virtual ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
        public virtual ICollection<Classroom> Classrooms { get; set; }
            = new List<Classroom>();
        public virtual ICollection<Subject> Subjects { get; set; }
            = new List<Subject>();
        public virtual ICollection<StudentLead> Leads { get; set; } = new List<StudentLead>();
        public virtual ICollection<Centersubscription> Subscriptions { get; set; }
            = new List<Centersubscription>();
        public virtual ICollection<Paymentgetway> PaymentGateways { get; set; }
            = new List<Paymentgetway>();
        public virtual ICollection<TeacherAssistant> TeacherAssistant { get; set; }
        = new List<TeacherAssistant>();
        public virtual ICollection<CenterAdmin> CenterAdmins { get; set; }
            = new List<CenterAdmin>();
        public virtual ICollection<QuestionBank> QuestionBanks { get; set; }
    }
}