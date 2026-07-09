using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class ManualGradeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManualGradeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ManualGrade
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.ManualGrades.GetAllAsync();
            return View(items);
        }

        // GET: ManualGrade/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.ManualGrades.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: ManualGrade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManualGrade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManualGrade model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.ManualGrades.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ManualGrade/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.ManualGrades.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ManualGrade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManualGrade model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.ManualGrades.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ManualGrade/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.ManualGrades.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ManualGrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.ManualGrades.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
