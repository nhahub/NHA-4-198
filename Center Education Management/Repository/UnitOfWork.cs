using Center_Education_Management.EFcore;
using Center_Education_Management.Repository.Implementations;
using Center_Education_Management.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Center_Education_Management.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CenterDBContext _context;
        private bool _disposed;

        private IAcademicSeasonRepository? _academicSeasons;
        private IAssignmentRepository? _assignments;
        private IAttendanceRepository? _attendances;
        private ICenterRepository? _centers;
        private ICenterAdminRepository? _centerAdmins;
        private ICenterOwnerRepository? _centerowners;
        private ICenterrequestRepository? _centerrequests;
        private ICentersubscriptionRepository? _centersubscriptions;
        private IClassroomRepository? _classrooms;
        private IContentRepository? _contents;
        private IEducationalStageRepository? _educationalStages;
        private IEnrollmentRepository? _enrollments;
        private IExamRepository? _exams;
        private IExamAnswerRepository? _examAnswers;
        private IExamAttemptRepository? _examAttempts;
        private IExamQuestionRepository? _examQuestions;
        private IGroupRepository? _groups;
        private IManualGradeRepository? _manualGrades;
        private INotificationRepository? _notifications;
        private IParentRepository? _parents;
        private IPaymentRepository? _payments;
        private IPaymentgetwayRepository? _paymentgetways;
        private IQRTokenRepository? _qRTokens;
        private IQuestionBankRepository? _questionBanks;
        private ISessionRepository? _sessions;
        private IStudentRepository? _students;
        private IStudentLeadRepository? _studentLeads;
        private ISubjectRepository? _subjects;
        private ISubscriptionPlanRepository? _subscriptionPlans;
        private ISuperadminRepository? _superadmins;
        private ITeacherRepository? _teachers;
        private ITeacherAssistantRepository? _assistants;
        private ITeacherEducationalStageRepository? _teacherEducationalStages;
        private IUserRepository? _users;

        // Cache للـ Repositories العامة (اللي بتتعمل عن طريق Repository<TEntity>())
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(CenterDBContext context)
        {
            _context = context;
        }

        public IAcademicSeasonRepository AcademicSeasons
            => _academicSeasons ??= new AcademicSeasonRepository(_context);

        public IAssignmentRepository Assignments
            => _assignments ??= new AssignmentRepository(_context);

        public IAttendanceRepository Attendances
            => _attendances ??= new AttendanceRepository(_context);

        public ICenterRepository Centers
            => _centers ??= new CenterRepository(_context);

        public ICenterAdminRepository CenterAdmins
            => _centerAdmins ??= new CenterAdminRepository(_context);

        public ICenterOwnerRepository Centerowners
            => _centerowners ??= new CenterOwnerRepository(_context);

        public ICenterrequestRepository Centerrequests
            => _centerrequests ??= new CenterrequestRepository(_context);

        public ICentersubscriptionRepository Centersubscriptions
            => _centersubscriptions ??= new CentersubscriptionRepository(_context);

        public IClassroomRepository Classrooms
            => _classrooms ??= new ClassroomRepository(_context);

        public IContentRepository Contents
            => _contents ??= new ContentRepository(_context);

        public IEducationalStageRepository EducationalStages
            => _educationalStages ??= new EducationalStageRepository(_context);

        public IEnrollmentRepository Enrollments
            => _enrollments ??= new EnrollmentRepository(_context);

        public IExamRepository Exams
            => _exams ??= new ExamRepository(_context);

        public IExamAnswerRepository ExamAnswers
            => _examAnswers ??= new ExamAnswerRepository(_context);

        public IExamAttemptRepository ExamAttempts
            => _examAttempts ??= new ExamAttemptRepository(_context);

        public IExamQuestionRepository ExamQuestions
            => _examQuestions ??= new ExamQuestionRepository(_context);

        public IGroupRepository Groups
            => _groups ??= new GroupRepository(_context);

        public IManualGradeRepository ManualGrades
            => _manualGrades ??= new ManualGradeRepository(_context);

        public INotificationRepository Notifications
            => _notifications ??= new NotificationRepository(_context);

        public IParentRepository Parents
            => _parents ??= new ParentRepository(_context);

        public IPaymentRepository Payments
            => _payments ??= new PaymentRepository(_context);

        public IPaymentgetwayRepository Paymentgetways
            => _paymentgetways ??= new PaymentgetwayRepository(_context);

        public IQRTokenRepository QRTokens
            => _qRTokens ??= new QRTokenRepository(_context);

        public IQuestionBankRepository QuestionBanks
            => _questionBanks ??= new QuestionBankRepository(_context);

        public ISessionRepository Sessions
            => _sessions ??= new SessionRepository(_context);

        public IStudentRepository Students
            => _students ??= new StudentRepository(_context);

        public IStudentLeadRepository StudentLeads
            => _studentLeads ??= new StudentLeadRepository(_context);

        public ISubjectRepository Subjects
            => _subjects ??= new SubjectRepository(_context);

        public ISubscriptionPlanRepository SubscriptionPlans
            => _subscriptionPlans ??= new SubscriptionPlanRepository(_context);

        public ISuperadminRepository Superadmins
            => _superadmins ??= new SuperadminRepository(_context);

        public ITeacherRepository Teachers
            => _teachers ??= new TeacherRepository(_context);

        public ITeacherAssistantRepository Assistants
            => _assistants ??= new TeacherAssistantRepository(_context);

        public ITeacherEducationalStageRepository TeacherEducationalStages
            => _teacherEducationalStages ??= new TeacherEducationalStageRepository(_context);

        public IUserRepository Users
            => _users ??= new UserRepository(_context);

        // ------------------- Fallback عام -------------------
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                var repoInstance = new GenericRepository<TEntity>(_context);
                _repositories[type] = repoInstance;
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        // ------------------- Save -------------------
        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        // ------------------- Dispose -------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
