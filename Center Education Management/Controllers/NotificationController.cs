using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Notifications.GetAllAsync();
            return View(items);
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Notification model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Notifications.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Notification/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Notification/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Notification model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Notifications.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Notifications.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
