using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Subjects.GetAllAsync();
            return View(items);
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Subjects.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Subjects.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Subjects.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subject model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Subjects.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Subjects.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Subjects.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
