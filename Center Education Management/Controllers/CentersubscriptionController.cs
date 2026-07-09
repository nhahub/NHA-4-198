using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class CentersubscriptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CentersubscriptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Centersubscription
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Centersubscriptions.GetAllAsync();
            return View(items);
        }

        // GET: Centersubscription/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Centersubscriptions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Centersubscription/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Centersubscription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Centersubscription model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Centersubscriptions.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Centersubscription/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Centersubscriptions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Centersubscription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Centersubscription model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Centersubscriptions.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Centersubscription/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Centersubscriptions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Centersubscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Centersubscriptions.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
