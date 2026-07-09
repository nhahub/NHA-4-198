using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Attendance
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Attendances.GetAllAsync();
            return View(items);
        }

        // GET: Attendance/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Attendances.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Attendance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attendance model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Attendances.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Attendance/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Attendances.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Attendance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Attendance model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Attendances.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Attendance/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Attendances.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Attendances.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
