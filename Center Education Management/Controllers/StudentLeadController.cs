using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Center_Education_Management.view_models;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class StudentLeadController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentLeadController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.StudentLeads.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.StudentLeads.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(StudentLeadCreateVM model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home", new { fragment = "contact" });

            var centers = await _unitOfWork.Centers.GetAllAsync();
            var stages = await _unitOfWork.EducationalStages.GetAllAsync();
            var subjects = await _unitOfWork.Subjects.GetAllAsync();

            var centerId = model.CenterId > 0 ? model.CenterId : centers.FirstOrDefault()?.Id ?? 0;
            var stageId = stages.FirstOrDefault()?.Id ?? 0;
            var subjectId = subjects.FirstOrDefault()?.Id ?? 0;

            if (centerId == 0 || stageId == 0 || subjectId == 0)
            {
                TempData["SuccessMessage"] = "تم استلام بياناتك، لكن يلزم إضافة سنتر ومرحلة ومادة من لوحة التحكم قبل حفظ الطلب كاملًا.";
                return RedirectToAction("Index", "Home", new { fragment = "contact" });
            }

            var lead = new StudentLead
            {
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                InterestedStageOrSubject = model.InterestedStageOrSubject,
                CenterId = centerId,
                StageId = stageId,
                SubjectId = subjectId,
                Status = StudentLeadStatus.Pending,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.StudentLeads.AddAsync(lead);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم تسجيل بيانات الطالب بنجاح، سنرشح لك السنتر والمدرس المناسب قريبًا.";
            return RedirectToAction("Index", "Home", new { fragment = "contact" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentLead model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.StudentLeads.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.StudentLeads.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentLead model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.StudentLeads.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.StudentLeads.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.StudentLeads.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
