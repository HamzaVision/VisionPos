using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisionPos.Data;
using VisionPos.Models;

namespace VisionPos.Areas.Items.Controllers
{
    [Area("Items")]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.tbItems.ToList());
        }

        public IActionResult Create()
        {
            var mod = new tbItems();
            return View("CreateAndEdit", mod);

        }

        public IActionResult Edit(int id)
        {
            var cus = _db.tbItems.FirstOrDefault(x => x.Id == id);
            return View("CreateAndEdit", cus);
        }


        [HttpPost]
        public async Task<IActionResult> Create(tbItems obj)
        {
            if (obj != null)
            {
                obj.CreationDate = DateTime.Now;
                _db.tbItems.Add(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(tbItems obj)
        {
            var sub = await _db.tbItems.FirstOrDefaultAsync(x => x.Id == obj.Id);
            sub.Name = obj.Name;
            sub.SalesRate = obj.SalesRate;
            sub.Active = obj.Active;
            if (sub != null)
            {
                _db.tbItems.Update(sub);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("CreateAndEdit", sub);

        }

        [HttpGet]
        public IActionResult GetItemDetails(int id)
        {
            var item = _db.tbItems.FirstOrDefault(x => x.Id == id);
            return PartialView("_ItemDetailsPartialView", item);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var cus = await _db.tbItems.FirstOrDefaultAsync(x => x.Id == id);
            if (cus != null)
            {
                _db.tbItems.Remove(cus);
                await _db.SaveChangesAsync();
                //return RedirectToAction("Index");
                return Ok();
            }
            return NotFound(); // Handle the case where the customer type with the given ID is not found.
        }
    }
}
