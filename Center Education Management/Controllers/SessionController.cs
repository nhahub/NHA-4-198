using Center_Education_Management.Model;
using Center_Education_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class SessionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Session
        public async Task<IActionResult> Index()
        {
            var items = await _unitOfWork.Sessions.GetAllAsync();
            return View(items);
        }

        // GET: Session/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _unitOfWork.Sessions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Session/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Session/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Session model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _unitOfWork.Sessions.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Session/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _unitOfWork.Sessions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Session/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Session model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            _unitOfWork.Sessions.Update(model);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Session/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _unitOfWork.Sessions.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.Sessions.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
