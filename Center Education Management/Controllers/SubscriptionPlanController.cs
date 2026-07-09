using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class SubscriptionPlanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionPlanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: SubscriptionPlan
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.SubscriptionPlans.GetAllAsync();
            return View(items);
        }

        // GET: SubscriptionPlan/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.SubscriptionPlans.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: SubscriptionPlan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubscriptionPlan model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.SubscriptionPlans.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: SubscriptionPlan/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.SubscriptionPlans.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: SubscriptionPlan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubscriptionPlan model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.SubscriptionPlans.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: SubscriptionPlan/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.SubscriptionPlans.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: SubscriptionPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.SubscriptionPlans.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
