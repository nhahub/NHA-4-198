using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class QuestionBankController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionBankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: QuestionBank
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.QuestionBanks.GetAllAsync();
            return View(items);
        }

        // GET: QuestionBank/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.QuestionBanks.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: QuestionBank/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionBank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionBank model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.QuestionBanks.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: QuestionBank/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.QuestionBanks.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: QuestionBank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QuestionBank model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.QuestionBanks.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: QuestionBank/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.QuestionBanks.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: QuestionBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.QuestionBanks.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
