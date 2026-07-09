using Center_Education_Management.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Center_Education_Management.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        // ------------------- Repositories الخاصة بكل Entity -------------------
        IAcademicSeasonRepository AcademicSeasons { get; }
        IAssignmentRepository Assignments { get; }
        IAttendanceRepository Attendances { get; }
        ICenterRepository Centers { get; }
        ICenterAdminRepository CenterAdmins { get; }
        ICenterOwnerRepository Centerowners { get; }
        ICenterrequestRepository Centerrequests { get; }
        ICentersubscriptionRepository Centersubscriptions { get; }
        IClassroomRepository Classrooms { get; }
        IContentRepository Contents { get; }
        IEducationalStageRepository EducationalStages { get; }
        IEnrollmentRepository Enrollments { get; }
        IExamRepository Exams { get; }
        IExamAnswerRepository ExamAnswers { get; }
        IExamAttemptRepository ExamAttempts { get; }
        IExamQuestionRepository ExamQuestions { get; }
        IGroupRepository Groups { get; }
        IManualGradeRepository ManualGrades { get; }
        INotificationRepository Notifications { get; }
        IParentRepository Parents { get; }
        IPaymentRepository Payments { get; }
        IPaymentgetwayRepository Paymentgetways { get; }
        IQRTokenRepository QRTokens { get; }
        IQuestionBankRepository QuestionBanks { get; }
        ISessionRepository Sessions { get; }
        IStudentRepository Students { get; }
        IStudentLeadRepository StudentLeads { get; }
        ISubjectRepository Subjects { get; }
        ISubscriptionPlanRepository SubscriptionPlans { get; }
        ISuperadminRepository Superadmins { get; }
        ITeacherRepository Teachers { get; }
        ITeacherAssistantRepository Assistants { get; }
        ITeacherEducationalStageRepository TeacherEducationalStages { get; }
        IUserRepository Users { get; }

        // ------------------- Fallback عام لأي Entity مالوش Repository خاص -------------------
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        // ------------------- Save -------------------
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
