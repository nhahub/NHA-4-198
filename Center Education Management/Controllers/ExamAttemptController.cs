using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class ExamAttemptController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamAttemptController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ExamAttempt
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.ExamAttempts.GetAllAsync();
            return View(items);
        }

        // GET: ExamAttempt/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.ExamAttempts.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: ExamAttempt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamAttempt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamAttempt model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.ExamAttempts.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamAttempt/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.ExamAttempts.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ExamAttempt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamAttempt model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.ExamAttempts.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamAttempt/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.ExamAttempts.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ExamAttempt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.ExamAttempts.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
