using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class TeacherAssistantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherAssistantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TeacherAssistant
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Assistants.GetAllAsync();
            return View(items);
        }

        // GET: TeacherAssistant/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Assistants.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: TeacherAssistant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherAssistant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherAssistant model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Assistants.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: TeacherAssistant/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Assistants.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: TeacherAssistant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherAssistant model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Assistants.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: TeacherAssistant/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Assistants.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: TeacherAssistant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Assistants.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
