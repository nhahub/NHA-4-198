using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class CenterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CenterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Center
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Centers.GetAllAsync();
            return View(items);
        }

        // GET: Center/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Centers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Center/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Center/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Center model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Centers.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Center/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Centers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Center/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Center model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Centers.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Center/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Centers.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Centers.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
