using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Center_Education_Management.serveses;
using Center_Education_Management.view_models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Center_Education_Management.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            var vm = students.Select(student => new StudentListVM
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Status = student.Status,
                StageName = student.Stage?.Name
            });

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student.DisplayStudent());
        }

        public async Task<IActionResult> Create()
        {
            await PopulateStudentListsAsync();
            return View(new CreateStudentVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentVM model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateStudentListsAsync(model.CenterId, model.StageId, model.ParentId);
                return View(model);
            }

            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                PasswordHash = model.Password,
                CenterId = model.CenterId,
                StageId = model.StageId,
                ParentId = model.ParentId,
                StudentCode = model.StudentCode,
                Status = StudentStatus.Active,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                JoinedAt = DateTime.Now
            };

            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            var vm = new UpdateStudentVM
            {
                Id = student.Id,
                StageId = student.StageId,
                StudentCode = student.StudentCode,
                Status = student.Status
            };

            await PopulateStudentListsAsync(stageId: student.StageId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateStudentVM model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateStudentListsAsync(stageId: model.StageId);
                return View(model);
            }

            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            student.StageId = model.StageId;
            student.StudentCode = model.StudentCode;
            student.Status = model.Status;
            student.UpdatedAt = DateTime.Now;

            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student.DisplayStudent());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Students.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateStudentListsAsync(int? centerId = null, int? stageId = null, int? parentId = null)
        {
            var centers = await _unitOfWork.Centers.GetAllAsync();
            var stages = await _unitOfWork.EducationalStages.GetAllAsync();
            var parents = await _unitOfWork.Parents.GetAllAsync();

            ViewBag.Centers = new SelectList(centers, "Id", "Name", centerId);
            ViewBag.Stages = new SelectList(stages, "Id", "Name", stageId);
            ViewBag.Parents = new SelectList(
                parents.Select(parent => new
                {
                    parent.Id,
                    Name = $"{parent.FirstName} {parent.LastName}".Trim()
                }),
                "Id",
                "Name",
                parentId);
        }
    }
}
