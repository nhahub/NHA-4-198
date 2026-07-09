using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class TeacherEducationalStageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherEducationalStageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TeacherEducationalStage
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.TeacherEducationalStages.GetAllAsync();
            return View(items);
        }

        // GET: TeacherEducationalStage/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.TeacherEducationalStages.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: TeacherEducationalStage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherEducationalStage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherEducationalStage model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.TeacherEducationalStages.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: TeacherEducationalStage/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.TeacherEducationalStages.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: TeacherEducationalStage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherEducationalStage model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.TeacherEducationalStages.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: TeacherEducationalStage/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.TeacherEducationalStages.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: TeacherEducationalStage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.TeacherEducationalStages.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
