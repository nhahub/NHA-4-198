using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Enrollments.GetAllAsync();
            return View(items);
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Enrollments.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollment model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Enrollments.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Enrollments.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Enrollment model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Enrollments.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Enrollments.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Enrollments.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
