using Center_Education_Management.EFcore;
using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using Center_Education_managment.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Center_Education_Management.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardApiController : ControllerBase
    {
        private readonly CenterDBContext _context;

        public DashboardApiController(CenterDBContext context)
        {
            _context = context;
        }

        [HttpGet("demo-data")]
        public async Task<IActionResult> DemoData()
        {
            var dbUsers = await _context.Users
                .OrderBy(x => x.Id)
                .ToListAsync();

            var users = dbUsers
                .Select(x => new
                {
                    id = x.Id,
                    role = x is Superadmin ? "super_admin"
                        : x is CenterOwner ? "center_owner"
                        : x is CenterAdmin ? "center_admin"
                        : x is Teacher ? "teacher"
                        : x is TeacherAssistant ? "assistant"
                        : x is Student ? "student"
                        : x is Parent ? "parent"
                        : "user",
                    email = x.Email ?? "",
                    password = x.PasswordHash ?? "123",
                    name = ((x.FirstName ?? "") + " " + (x.LastName ?? "")).Trim(),
                    centerId = x is CenterOwner owner && owner.center != null ? owner.center.Id
                        : x is CenterAdmin admin ? admin.CenterId
                        : x is Teacher teacher ? teacher.CenterId
                        : x is Student student ? student.CenterId
                        : (int?)null
                })
                .ToList();

            var demoUsers = new[]
            {
                new { id = -1, role = "super_admin", email = "super@admin.com", password = "123", name = "Platform Admin", centerId = (int?)null },
                new { id = -2, role = "center_owner", email = "owner@center.com", password = "123", name = "Demo Owner", centerId = (int?)1 },
                new { id = -3, role = "center_admin", email = "admin@center.com", password = "123", name = "Demo Admin", centerId = (int?)1 },
                new { id = -4, role = "teacher", email = "teacher@center.com", password = "123", name = "Demo Teacher", centerId = (int?)1 },
                new { id = -5, role = "assistant", email = "assistant@center.com", password = "123", name = "Demo Assistant", centerId = (int?)1 },
                new { id = -6, role = "student", email = "student@center.com", password = "123", name = "Demo Student", centerId = (int?)1 },
                new { id = -7, role = "parent", email = "parent@center.com", password = "123", name = "Demo Parent", centerId = (int?)1 }
            };

            var centers = await _context.Centers
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    email = x.Owner != null ? x.Owner.Email : "",
                    phone = x.Phone,
                    address = x.Address,
                    city = x.City,
                    government = x.City,
                    status = x.Status.ToString().ToLower(),
                    plan = x.Subscriptions
                        .OrderByDescending(s => s.StartsAt)
                        .Select(s => s.Plan != null ? s.Plan.Name : "Free")
                        .FirstOrDefault() ?? "Free",
                    ownerId = x.OwnerId,
                    createdAt = x.CreatedAt.ToString("yyyy-MM-dd")
                })
                .ToListAsync();

            var centerRequests = await _context.Centerrequests
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new
                {
                    id = x.Id,
                    centerName = x.CenterName,
                    contactPhone = x.ContactPhone,
                    address = x.Address,
                    city = x.City,
                    state = x.State.ToString(),
                    createdAt = x.CreatedAt.ToString("yyyy-MM-dd")
                })
                .ToListAsync();

            var plans = await _context.SubscriptionPlans
                .OrderBy(x => x.PriceMonthly)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    priceMonthly = x.PriceMonthly,
                    maxStudents = x.MaxStudents,
                    maxTeachers = x.MaxTeachers,
                    maxGroups = x.MaxGroups,
                    storageGB = x.StorageGB
                })
                .ToListAsync();

            var teachers = await _context.Teachers
                .Select(x => new
                {
                    id = x.Id,
                    name = ((x.FirstName ?? "") + " " + (x.LastName ?? "")).Trim(),
                    subject = x.Subject != null ? x.Subject.Name : "",
                    email = x.Email,
                    phone = x.Phone,
                    centerId = x.CenterId
                })
                .ToListAsync();

            var groups = await _context.Groups
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    subject = x.Subject != null ? x.Subject.Name : "",
                    stage = x.Stage != null ? x.Stage.Name : "",
                    teacherId = x.TeacherId,
                    assistantId = (int?)null,
                    classroom = x.Classroom != null ? x.Classroom.Name : "",
                    schedule = "",
                    capacity = x.MaxCapacity,
                    centerId = x.CenterId
                })
                .ToListAsync();

            var students = await _context.Students
                .Select(x => new
                {
                    id = x.Id,
                    name = ((x.FirstName ?? "") + " " + (x.LastName ?? "")).Trim(),
                    email = x.Email,
                    phone = x.Phone,
                    stage = x.Stage != null ? x.Stage.Name : "",
                    subject = "",
                    parentPhone = x.Parent != null ? x.Parent.Phone : "",
                    centerId = x.CenterId,
                    groupIds = x.GroupEnrollments.Select(e => e.GroupId).ToList()
                })
                .ToListAsync();

            var studentLeads = await _context.StudentLeads
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    phone = x.Phone,
                    email = x.Email,
                    stage = x.InterestedStageOrSubject,
                    subject = x.Subject != null ? x.Subject.Name : "",
                    status = x.Status.ToString(),
                    centerId = x.CenterId
                })
                .ToListAsync();

            var payments = await _context.Payments
                .Select(x => new
                {
                    id = x.Id,
                    studentId = x.StudentId,
                    amount = x.Amount,
                    type = "Payment",
                    status = x.Status.ToString().ToLower(),
                    date = x.CreatedAt.ToString("yyyy-MM-dd")
                })
                .ToListAsync();

            return Ok(new
            {
                users = demoUsers.Concat(users),
                centers,
                centerRequests,
                plans,
                teachers,
                assistants = Array.Empty<object>(),
                groups,
                students,
                studentLeads,
                sessions = Array.Empty<object>(),
                attendance = Array.Empty<object>(),
                exams = Array.Empty<object>(),
                questionBank = Array.Empty<object>(),
                examRecords = Array.Empty<object>(),
                payments,
                content = Array.Empty<object>(),
                assignments = Array.Empty<object>(),
                submissions = Array.Empty<object>(),
                notifications = Array.Empty<object>()
            });
        }

        [HttpGet("super-admin")]
        public async Task<IActionResult> SuperAdmin()
        {
            var requests = await _context.Centerrequests
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new
                {
                    id = x.Id,
                    centerName = x.CenterName,
                    contactPhone = x.ContactPhone,
                    address = x.Address,
                    city = x.City,
                    state = x.State.ToString(),
                    createdAt = x.CreatedAt.ToString("yyyy-MM-dd")
                })
                .ToListAsync();

            var centers = await _context.Centers
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    email = x.Owner != null ? x.Owner.Email : "",
                    phone = x.Phone,
                    address = x.Address,
                    city = x.City,
                    status = x.Status.ToString(),
                    plan = x.Subscriptions
                        .OrderByDescending(s => s.StartsAt)
                        .Select(s => s.Plan != null ? s.Plan.Name : "Free")
                        .FirstOrDefault() ?? "Free",
                    createdAt = x.CreatedAt.ToString("yyyy-MM-dd")
                })
                .ToListAsync();

            var plans = await _context.SubscriptionPlans
                .OrderBy(x => x.PriceMonthly)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.Name,
                    priceMonthly = x.PriceMonthly,
                    maxStudents = x.MaxStudents,
                    maxTeachers = x.MaxTeachers,
                    maxGroups = x.MaxGroups,
                    storageGB = x.StorageGB,
                    isActive = x.IsActive
                })
                .ToListAsync();

            var users = await _context.Users
                .OrderByDescending(x => x.Id)
                .Select(x => new
                {
                    id = x.Id,
                    name = ((x.FirstName ?? "") + " " + (x.LastName ?? "")).Trim(),
                    email = x.Email,
                    phone = x.Phone,
                    role = x.GetType().Name,
                    isActive = x.IsActive
                })
                .ToListAsync();

            return Ok(new
            {
                requests,
                centers,
                plans,
                users,
                stats = new
                {
                    totalCenters = centers.Count,
                    pendingRequests = requests.Count(x => x.state == CenterRequestStatus.waiting.ToString()),
                    activeSubscriptions = centers.Count(x => x.status == CenterStatus.Active.ToString()),
                    totalUsers = users.Count,
                    monthlyRevenue = plans.Where(x => x.isActive).Sum(x => x.priceMonthly)
                }
            });
        }

        [HttpPost("center-requests/{id:int}/approve")]
        public async Task<IActionResult> ApproveCenterRequest(int id)
        {
            var request = await _context.Centerrequests.FindAsync(id);
            if (request == null)
                return NotFound();

            if (request.State == CenterRequestStatus.approved)
                return Ok();

            var now = DateTime.Now;
            var emailSuffix = $"{id}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            var owner = new CenterOwner
            {
                FirstName = request.CenterName ?? "Center",
                LastName = "Owner",
                Email = $"owner-{emailSuffix}@teachflow.local",
                PasswordHash = "123",
                Phone = request.ContactPhone ?? "00000000000",
                IsActive = true,
                EmailVerified = false,
                CreatedAt = now,
                UpdatedAt = now,
                JoinedAt = now,
                OwnershipType = OwnershipType.Individual,
                SubscriptionStatus = SubscriptionStatus.Active,
                DefaultPaymentMethod = PaymentMethod.Cash
            };

            _context.Centerowners.Add(owner);
            await _context.SaveChangesAsync();

            var center = new Center
            {
                OwnerId = owner.Id,
                Name = request.CenterName,
                Slug = $"center-{id}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}",
                Address = request.Address,
                City = request.City,
                Phone = request.ContactPhone,
                Status = CenterStatus.Active,
                CreatedAt = now,
                UpdatedAt = now,
                VerifiedAt = now
            };

            _context.Centers.Add(center);
            request.State = CenterRequestStatus.approved;
            request.ReviewedAt = now;

            await _context.SaveChangesAsync();
            return Ok(new { owner.Email, password = "123" });
        }

        [HttpPost("center-requests/{id:int}/reject")]
        public async Task<IActionResult> RejectCenterRequest(int id)
        {
            var request = await _context.Centerrequests.FindAsync(id);
            if (request == null)
                return NotFound();

            request.State = CenterRequestStatus.rejected;
            request.ReviewedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
