using Center_Education_Management.Models;
using Center_Education_Management.view_models;
using static Center_Education_Management.view_models.ManualGradeVM;

namespace Center_Education_Management.serveses
{
    public static class DisplayVM
    {
        public static CenterDetailsVM DisplayCenterVM(this Center center)
        {
            return new CenterDetailsVM
            {
                Id = center.Id,
                Name = center.Name,
                Slug = center.Slug,
                Description = center.Description,
                LogoUrl = center.LogoUrl,
                Address = $"{center.Address} {center.City}",
                Phone = center.Phone,
                Status = center.Status.ToString(),
                VerifiedAt = center.VerifiedAt,
                CreatedAt = center.CreatedAt,
                OwnerName = $"{center.Owner.FirstName} {center.Owner.LastName}",
                VerifiedByAdminName = center.VerifiedByAdmin != null ? center.VerifiedByAdmin.Name : null
            };
        }
        public static CenterOwnerDetailsVM DisplayCenterOwnerVM(this CenterOwner owner)
        {
            return new CenterOwnerDetailsVM
            {
                Id = owner.Id,
                FullName = $"{owner.FirstName} {owner.LastName}",
                NationalID = owner.NationalID,
                Email = owner.Email,
                Phone = owner.Phone,
                AvatarUrl = owner.AvatarUrl,
                OwnershipType = owner.OwnershipType.ToString(),
                SubscriptionStatus = owner.SubscriptionStatus.ToString(),
                DefaultPaymentMethod = owner.DefaultPaymentMethod.ToString(),
                JoinedAt = owner.JoinedAt,
                CenterName = owner.center != null ? owner.center.Name : null
            };
        }
        public static CenterRequestDetailsVM DisplayCenterRequestVM(this Centerrequest request)
        {
            return new CenterRequestDetailsVM
            {
                Id = request.Id,
                CenterName = request.CenterName,
                ContactPhone = request.ContactPhone,
                Address = $"{request.Address} {request.City}",
                State = request.State.ToString(),
                CreatedAt = request.CreatedAt,
                ReviewedAt = request.ReviewedAt,
                ReviewedByAdminName = request.ReviewedBy != null ? request.ReviewedBy.Name : null
            };
        }
        public static CenterSubscriptionDetailsVM DisplayCenterSubscriptionVM(this Centersubscription subscription)
        {
            return new CenterSubscriptionDetailsVM
            {
                SubscriptionId = subscription.Id,
                Status = subscription.Status.ToString(),
                BillingCycle = subscription.BillingCycle.ToString(),
                StartsAt = subscription.StartsAt,
                EndsAt = subscription.EndsAt,
                ApprovedAt = subscription.ApprovedAt,
                CenterName = subscription.Center.Name,
                PlanName = subscription.Plan.Name,
                ApprovedByAdminName = subscription.ApprovedByAdmin != null ? subscription.ApprovedByAdmin.Name : null
            };
        }
        public static PaymentDetailsVM DisplayPaymentVM(this Payment payment)
        {
            return new PaymentDetailsVM
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Method = payment.Method.ToString(),
                Status = payment.Status.ToString(),
                PaidAt = payment.PaidAt,
                CreatedAt = payment.CreatedAt,
                StudentName = $"{payment.Student.FirstName} {payment.Student.LastName}",
                CenterName = payment.Center.Name,
                GroupName = payment.Group != null ? payment.Group.Name : null,
                GatewayName = payment.PaymentGateway?.Provider.ToString(),
                RecordedByUserName = payment.RecordedByUser != null ? $"{payment.RecordedByUser.FirstName} {payment.RecordedByUser.LastName}" : null
            };
        }
        public static SubscriptionPlanVM DisplaySubscriptionPlanVM(this SubscriptionPlan plan)
        {
            return new SubscriptionPlanVM
            {
                PlanId = plan.Id,
                Name = plan.Name,
                PriceMonthly = plan.PriceMonthly,
                PriceYearly = plan.PriceYearly,
                PriceSemester = plan.PriceSemester,
                MaxGroups = plan.MaxGroups,
                MaxStudents = plan.MaxStudents,
                MaxTeachers = plan.MaxTeachers,
                StorageGB = plan.StorageGB,
                IsActive = plan.IsActive
            };
        }
        public static ParentDetailsVM DisplayParent(this Parent parent)
        {
            return new ParentDetailsVM
            {
                ParentId = parent.Id,
                Name = $"{parent.FirstName} {parent.LastName}",
                Email = parent.Email,
                PhoneNumber = parent.Phone,
                Permissions = parent.Permissions,
                StudentNames = parent.Students != null ? parent.Students.Select(s => $"{s.FirstName} {s.LastName}").ToList() : new List<string>()
            };
        }
        public static AttendanceDetailsVM Displayattendance(this Attendance attendance)
        {
            return new AttendanceDetailsVM
            {
                Status = attendance.Status.ToString(),
                AttendanceMode = attendance.AttendanceMode.ToString(),
                StudentName = $"{attendance.Student.FirstName} {attendance.Student.LastName}",
                SessionTitle = attendance.Session.Title,
                RecordedAt = attendance.RecordedAt,
                RecordedByUserName = attendance.RecordedByUser != null ? $"{attendance.RecordedByUser.FirstName} {attendance.RecordedByUser.LastName}" : null
            };
        }
        public static EnrollmentDetailsVM Displayenrollment(this Enrollment enrollment)
        {
            return new EnrollmentDetailsVM
            {
                StudentName = $"{enrollment.Student.FirstName} {enrollment.Student.LastName}",
                GroupName = $"{enrollment.Group.Name}",
                CenterName = $"{enrollment.Center.Name}",
                Status = enrollment.Status.ToString(),
                EnrollmentId = enrollment.Id
            };
        }
        public static StudentLeadReadVM DisplayStudentLead(this StudentLead lead)
        {
            return new StudentLeadReadVM
            {
                LeadId = lead.Id,
                Name = lead.Name,
                Phone = lead.Phone,
                Email = lead.Email,
                InterestedStageOrSubject = lead.InterestedStageOrSubject,
                Status = lead.Status.ToString(),
                CreatedAt = lead.CreatedAt,
                CenterId = lead.CenterId,
                CenterName = lead.Center != null ? lead.Center.Name : null
            };
        }
        public static NotificationReadVM DisplayNotification(this Notification notification)
        {
            return new NotificationReadVM
            {
                Id = notification.Id,
                UserId = notification.UserId,
                UserName = notification.User != null ? $"{notification.User.FirstName} {notification.User.LastName}" : null,
                Type = notification.Type.ToString(),
                Title = notification.Title,
                Body = notification.Body,
                IsRead = notification.IsRead,
                RefType = notification.RefType,
                CreatedAt = notification.CreatedAt,
            };
        }
        public static QuestionBankReadVM DisplayQuestionBank(this QuestionBank questionBank)
        {
            return new QuestionBankReadVM
            {
                Id = questionBank.Id,
                TeacherName = questionBank.Teacher != null ? $"{questionBank.Teacher.FirstName} {questionBank.Teacher.LastName}" : null,
                CenterName = questionBank.Center != null ? $"{questionBank.Center.Name}" : null,
                Subject = questionBank.Subject.Name, // class
                Lesson = questionBank.Lesson, // class
                Type = questionBank.Type.ToString(),
                Body = questionBank.Body,
                Options = questionBank.OptionsJson,
                CorrectAnswer = questionBank.CorrectAnswer,
                Points = questionBank.Points
            };
        }
        public static ExamVM DisplayExam(this Exam exam)
        {
            return new ExamVM
            {
                Id = exam.Id,
                TeacherName = exam.Teacher != null ? $"{exam.Teacher.FirstName} {exam.Teacher.LastName}" : null,
                GroupName = exam.Group != null ? $"{exam.Group.Name}" : null,
                Title = exam.Title,
                Subject = exam.Subject.Name,
                DurationMinutes = exam.DurationMinutes,
                TotalPoints = exam.Questions != null ? (int)exam.Questions.Sum(q => q.Points) : 0,
                ShuffleQuestions = exam.ShuffleQuestions,
                ShuffleOptions = exam.ShuffleOptions,
                ShowResultsAt = exam.ShowResultsAt.ToString(),
                StartsAt = exam.StartsAt.ToString(),
                EndsAt = exam.EndsAt.ToString(),
                Status = exam.Status.ToString(),
                QuestionCount = exam.Questions != null ? exam.Questions.Count : 0
            };
        }
        public static ExamQuestionReadVM DisplayExamQuestion(this ExamQuestion question)
        {
            return new ExamQuestionReadVM
            {
                Id = question.Id,
                OrderIndex = question.OrderIndex,
                Body = question.BodySnapshot,
                Options = question.OptionsSnapshot,
                CorrectAnswer = question.CorrectAnswer,
                Points = question.Points
            };
        }
        public static ExamQuestionVM DisplayStudentExamQuestion(this ExamAnswer examAnswer)
        {
            return new ExamQuestionVM
            {
                AnswerId = examAnswer.Id,
                OrderIndex = examAnswer.ExamQuestion.OrderIndex,
                Body = examAnswer.ExamQuestion.BodySnapshot,
                Type = examAnswer.ExamQuestion.Type.ToString(),
                Options = examAnswer.ExamQuestion.OptionsSnapshot,
                Points = (int)examAnswer.ExamQuestion.Points,
                AnswerText = examAnswer.AnswerText,
                SavedAt = examAnswer.SavedAt.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
        public static ExamResultVM DisplayExamResult(this ExamAttempt attempt)
        {
            var totalPoints = attempt.Exam?.Questions.Sum(q => q.Points) ?? 0;
            double percentage = totalPoints > 0 ? ((double)(attempt.Score ?? 0) / (double)totalPoints) * 100 : 0;

            return new ExamResultVM
            {
                ExamId = attempt.ExamId,
                StudentId = attempt.StudentId,
                StudentName = $"{attempt.Student.FirstName} {attempt.Student.LastName}",
                Score = attempt.Score ?? 0,
                TotalPoints = (int)totalPoints,
                Percentage = percentage,
                AttemptStatus = attempt.Status.ToString(),
                SubmittedAt = attempt.SubmittedAt.ToString()
            };
        }
        public static ExamAnalyticsVM DisplayExamAnalytics(this Exam exam)
        {
            var totalAttempts = exam.Attempts.Count;
            var averageScore = totalAttempts > 0 ? exam.Attempts.Average(a => a.Score ?? 0) : 0;
            var highestScore = totalAttempts > 0 ? exam.Attempts.Max(a => a.Score ?? 0) : 0;
            var lowestScore = totalAttempts > 0 ? exam.Attempts.Min(a => a.Score ?? 0) : 0;
            return new ExamAnalyticsVM
            {
                ExamId = exam.Id,
                Title = exam.Title,
                TotalAttempts = totalAttempts,
                AverageScore = (double)averageScore,
                HighestScore = (double)highestScore,
                LowestScore = (double)lowestScore
            };
        }
        public static ClassroomDetailsVM DisplayClassRoom(this Classroom classroom)
        {
            return new ClassroomDetailsVM
            {
                Id = classroom.Id,
                CenterId = classroom.CenterId,
                Name = $"{classroom.Name}",
                Capacity = classroom.Capacity,
                Type = classroom.Type.ToString(),
                IsActive = classroom.IsActive,
                SessionsCount = classroom.Sessions != null ? classroom.Sessions.Count : 0
            };
        }
        public static QRTokenDetailsVM DisplayQRToken(this QRToken token)
        {
            var isExpired = token.ExpiresAt < DateTime.UtcNow;
            var remainingSeconds = (int)(token.ExpiresAt - DateTime.UtcNow).TotalSeconds;
            return new QRTokenDetailsVM
            {
                Id = token.Id,
                SessionId = token.SessionId,
                Token = token.Token,
                GeneratedAt = token.GeneratedAt,
                ExpiresAt = token.ExpiresAt,
                Status = token.Status.ToString(),
                IsExpired = isExpired,
                RemainingSeconds = remainingSeconds > 0 ? remainingSeconds : 0,
                GeneratedBy = token.GenrateUser != null ? $"{token.GenrateUser.FirstName} {token.GenrateUser.LastName}" : null
            };
        }
        public static ContentDetailsVM DisplayContent(this Content content)
        {
            return new ContentDetailsVM
            {
                Id = content.Id,
                GroupId = content.GroupId,
                SessionId = content.SessionId,
                UploadedBy = content.UploadedByID,
                Type = content.Type.ToString(),
                Title = content.Title,
                Url = content.Url,
                SizeBytes = content.SizeBytes,
                Visibility = content.Visibility.ToString(),
                CreatedAt = content.CreatedAt,
                UploadedByName = content.UploadedByUser.ToString()
                //GroupName and SessionTitle
            };


        }
        public static AssignmentReadVM DisplayAssignmentVM(this Assignment Assignment)
        {
            return new AssignmentReadVM
            {
                AssignmentId = Assignment.Id,
                Name = Assignment.Name,
                StartDate = Assignment.StartDate,
                DueDate = Assignment.DueDate,
                TeacherName = Assignment.Teacher != null ? $"{Assignment.Teacher.FirstName} {Assignment.Teacher.LastName}" : null,
                GroupName = Assignment.Group != null ? Assignment.Group.Name : null,
                Status = Assignment.Status.ToString()
            };
        }
        public static TeacherdetilesVM DisplayTeacher(this Teacher teacher)
        {
            return new TeacherdetilesVM
            {
                TeacherId = teacher.Id,
                FullName = $"{teacher.FirstName} {teacher.LastName}",
                Email = teacher.Email,
                Phone = teacher.Phone,
                Subjectname = teacher.Subject != null ? teacher.Subject.Name : null,
                CenterId = teacher.CenterId,
                Bio = teacher.Bio,
                IsActive = teacher.IsActive,
                JoinedAt = teacher.JoinedAt,
                Centername = teacher.Center != null ? teacher.Center.Name : null,
                Salary = teacher.Salary

            };
        }
        public static StudentDetailsVM DisplayStudent(this Student student)
        {
            return new StudentDetailsVM
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                CenterName = student.Center?.Name,
                StageName = student.Stage?.Name,
                Status = student.Status.ToString(),
                BlockedReason = student.BlockedReason,
                JoinedAt = student.JoinedAt
            };
        }
        public static GroupDetailsVM DisplayGroup(this Group group)
        {
            return new GroupDetailsVM
            {
                GroupId = group.Id,
                Name = group.Name,
                CenterName = group.Center?.Name,
                StageName = group.Stage?.Name,
                TeacherName = group.Teacher != null
                    ? $"{group.Teacher.FirstName} {group.Teacher.LastName}"
                    : null,
                StudentCount = group.Enrollments?.Count ?? 0,
                MaxCapacity = group.MaxCapacity,
            };
        }
        public static AcademicSeasonVM DisplayAcademicSeason(this AcademicSeason season)
        {
            return new AcademicSeasonVM
            {
                SeasonId = season.Id,
                CenterId = season.CenterId,
                Name = season.Name,
                Type = season.Type.ToString(),
                StartsAt = season.StartsAt.ToString("yyyy-MM-dd"),
                EndsAt = season.EndsAt.ToString("yyyy-MM-dd"),
                Status = season.Status.ToString(),
                IsCurrent = season.IsCurrent
            };
        }
        public static CenterAdminDetailsVM DisplayCenterAdminDetails(this CenterAdmin admin)
        {
            return new CenterAdminDetailsVM
            {
                Id = admin.Id,
                CenterId = admin.Id,
                FullName = $"{admin.FirstName} {admin.LastName}",
                Email = admin.Email,
                Phone = admin.Phone,
                Role = admin.Role.ToString(),
                GrantedBy = admin.GrantedBy != null ? $"{admin.GrantedBy.FirstName} {admin.GrantedBy.LastName}" : null,
                GrantedAt = admin.GrantedAt,
                IsActive = admin.IsActive,
                Salary = admin.Salary
            };
        }
        public static EducationalStageDetailsVM DisplayEducationStage(this EducationalStage stage)
        {
            return new EducationalStageDetailsVM
            {
                StageId = stage.Id,
                Name = stage.Name,
                LevelNumber = stage.LevelNumber,
                DisplayName = stage.DisplayName,
                EducationSystem = stage.EducationSystem,
                IsActive = stage.IsActive,
                StudentsCount = stage.Students != null ? stage.Students.Count : 0,
                GroupsCount = stage.Groups != null ? stage.Groups.Count : 0
            };
        }
        public static ManualGradeDetailsVM DisplayManualGrade(this ManualGrade grade)
        {
            return new ManualGradeDetailsVM
            {
                Id = grade.Id,
                StudentName = grade.Student != null ? $"{grade.Student.FirstName} {grade.Student.LastName}" : null,
                GroupName = grade.Group != null ? grade.Group.Name : null,
                SubjectName = grade.Subject != null ? grade.Subject.Name : null,
                AssistantName = grade.RecordedByUser != null ? $"{grade.RecordedByUser.FirstName} {grade.RecordedByUser.LastName}" : null,
                Points = grade.Points,
                GradedAt = grade.GradedAt
            };

        }
        public static SessionDetailsVM DisplaySessions(this Session session)
        {
            return new SessionDetailsVM
            {
                SessionId = session.Id,
                Title = session.Title,
                TeacherName = session.Teacher != null ? $"{session.Teacher.FirstName} {session.Teacher.LastName}" : null,
                GroupName = session.Group != null ? session.Group.Name : null,
                classroom = session.Classroom != null ? session.Classroom.Name : null,
            };
        }
        public static TeacherEducationalStageDetailsVM DisplayTeacherEducationalStage(this TeacherEducationalStage teacherEducationalStageDetails)
        {
            return new TeacherEducationalStageDetailsVM
            {
                TeacherId = teacherEducationalStageDetails.Id,
                TeacherName = teacherEducationalStageDetails.Teacher != null ? $"{teacherEducationalStageDetails.Teacher.FirstName} {teacherEducationalStageDetails.Teacher.LastName}" : null,
                StageId = teacherEducationalStageDetails.StageId,
                StageName = teacherEducationalStageDetails.Stage != null ? teacherEducationalStageDetails.Stage.Name : null,
                SubjectName = teacherEducationalStageDetails.Teacher != null && teacherEducationalStageDetails.Teacher.Subject != null ? teacherEducationalStageDetails.Teacher.Subject.Name : null,
                CenterName = teacherEducationalStageDetails.Teacher != null && teacherEducationalStageDetails.Teacher.Center != null ? teacherEducationalStageDetails.Teacher.Center.Name : null
            };
        }
        public static LeadInterestedSubjectDetailsVM DisplayLeadInterestedSubject(this StudentLead lead)
        {
            return new LeadInterestedSubjectDetailsVM
            {
                LeadId = lead.Id,
                FullName = lead.Name,
                PhoneNumber = lead.Phone,
                SubjectName = lead.Subject != null ? lead.Subject.Name : null,
                StageName = lead.Stage != null ? lead.Stage.Name : null,
                CenterName = lead.Center != null ? lead.Center.Name : null,
                Status = lead.Status.ToString(),
                CreatedAt = lead.CreatedAt
            };
        }
    }
}