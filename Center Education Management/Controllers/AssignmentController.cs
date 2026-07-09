using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Assignment
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Assignments.GetAllAsync();
            return View(items);
        }

        // GET: Assignment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Assignments.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Assignment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Assignment model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Assignments.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Assignment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Assignments.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Assignment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Assignment model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Assignments.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Assignment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Assignments.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Assignments.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
