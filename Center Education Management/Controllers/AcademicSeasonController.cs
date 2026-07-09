using Center_Education_Management.Models;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class AcademicSeasonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademicSeasonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: AcademicSeason
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.AcademicSeasons.GetAllAsync();
            return View(items);
        }

        // GET: AcademicSeason/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.AcademicSeasons.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: AcademicSeason/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicSeason/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademicSeason model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.AcademicSeasons.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: AcademicSeason/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.AcademicSeasons.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: AcademicSeason/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AcademicSeason model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.AcademicSeasons.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: AcademicSeason/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.AcademicSeasons.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: AcademicSeason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.AcademicSeasons.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
