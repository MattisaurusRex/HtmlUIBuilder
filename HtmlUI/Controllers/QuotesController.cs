using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmlUI.Controllers
{
    public class QuotesController : Controller
    {
        // GET: QuotesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuotesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuotesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuotesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuotesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuotesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuotesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
