using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class SuperadminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuperadminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Superadmin
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Superadmins.GetAllAsync();
            return View(items);
        }

        // GET: Superadmin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Superadmins.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Superadmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Superadmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Superadmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Superadmins.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Superadmin/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Superadmins.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Superadmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Superadmin model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Superadmins.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Superadmin/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Superadmins.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Superadmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Superadmins.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
