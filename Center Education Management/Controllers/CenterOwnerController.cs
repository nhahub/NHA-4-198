using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class CenterOwnerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CenterOwnerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CenterOwner
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Centerowners.GetAllAsync();
            return View(items);
        }

        // GET: CenterOwner/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Centerowners.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: CenterOwner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CenterOwner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CenterOwner model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Centerowners.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: CenterOwner/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Centerowners.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: CenterOwner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CenterOwner model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Centerowners.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: CenterOwner/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Centerowners.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: CenterOwner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Centerowners.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
