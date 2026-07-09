using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class ParentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Parent
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Parents.GetAllAsync();
            return View(items);
        }

        // GET: Parent/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Parents.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Parent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Parent model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Parents.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Parent/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Parents.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Parent model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Parents.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Parent/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Parents.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Parents.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
