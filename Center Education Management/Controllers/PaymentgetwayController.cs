using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class PaymentgetwayController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentgetwayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Paymentgetway
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Paymentgetways.GetAllAsync();
            return View(items);
        }

        // GET: Paymentgetway/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Paymentgetways.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Paymentgetway/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paymentgetway/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paymentgetway model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Paymentgetways.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Paymentgetway/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Paymentgetways.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Paymentgetway/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paymentgetway model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Paymentgetways.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Paymentgetway/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Paymentgetways.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Paymentgetway/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Paymentgetways.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
