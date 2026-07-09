using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Teacher
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Teachers.GetAllAsync();
            return View(items);
        }

        // GET: Teacher/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Teachers.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Teacher/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Teacher model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Teachers.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Teacher/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Teachers.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
