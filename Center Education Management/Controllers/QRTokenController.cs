using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class QRTokenController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QRTokenController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: QRToken
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.QRTokens.GetAllAsync();
            return View(items);
        }

        // GET: QRToken/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.QRTokens.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: QRToken/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QRToken/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QRToken model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.QRTokens.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: QRToken/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.QRTokens.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: QRToken/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QRToken model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.QRTokens.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: QRToken/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.QRTokens.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: QRToken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.QRTokens.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
