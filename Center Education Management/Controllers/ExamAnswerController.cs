using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class ExamAnswerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamAnswerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ExamAnswer
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.ExamAnswers.GetAllAsync();
            return View(items);
        }

        // GET: ExamAnswer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.ExamAnswers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: ExamAnswer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamAnswer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamAnswer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.ExamAnswers.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamAnswer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.ExamAnswers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ExamAnswer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamAnswer model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.ExamAnswers.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ExamAnswer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.ExamAnswers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: ExamAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.ExamAnswers.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
