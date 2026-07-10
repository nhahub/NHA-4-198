using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class CenterAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CenterAdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CenterAdmin
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.CenterAdmins.GetAllAsync();
            return View(items);
        }

        // GET: CenterAdmin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.CenterAdmins.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: CenterAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CenterAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CenterAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.CenterAdmins.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: CenterAdmin/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.CenterAdmins.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: CenterAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CenterAdmin model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.CenterAdmins.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: CenterAdmin/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.CenterAdmins.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: CenterAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.CenterAdmins.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
