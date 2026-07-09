using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Center_Education_Management.view_models;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class CenterrequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CenterrequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Centerrequests.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Centerrequests.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateCenterRequestVM model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home", new { fragment = "contact" });

            var request = new Centerrequest
            {
                CenterName = model.CenterName,
                ContactPhone = model.ContactPhone,
                Address = model.Address,
                City = model.City,
                State = CenterRequestStatus.waiting,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.Centerrequests.AddAsync(request);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم إرسال طلب السنتر بنجاح، سنراجع البيانات ونتواصل معك قريبًا.";
            return RedirectToAction("Index", "Home", new { fragment = "contact" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Centerrequest model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Centerrequests.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Centerrequests.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Centerrequest model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Centerrequests.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Centerrequests.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Centerrequests.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
