using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class EducationalStageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationalStageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: EducationalStage
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.EducationalStages.GetAllAsync();
            return View(items);
        }

        // GET: EducationalStage/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.EducationalStages.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: EducationalStage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationalStage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EducationalStage model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.EducationalStages.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: EducationalStage/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.EducationalStages.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: EducationalStage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EducationalStage model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.EducationalStages.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: EducationalStage/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.EducationalStages.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: EducationalStage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.EducationalStages.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
