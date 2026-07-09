using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class ExamQuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamQuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ExamQuestion
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.ExamQuestions.GetAllAsync();
            return View(items);
        }

        // GET: ExamQuestion/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.ExamQuestions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: ExamQuestion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamQuestion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamQuestion model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.ExamQuestions.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamQuestion/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.ExamQuestions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ExamQuestion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamQuestion model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.ExamQuestions.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamQuestion/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.ExamQuestions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ExamQuestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.ExamQuestions.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
