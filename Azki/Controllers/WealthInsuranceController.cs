using Azki.Data.Interfaces;
using Azki.Data;
using System.Web.Mvc;
using Azki.Data.Implements;

namespace Azki.Controllers
{
    public class WealthInsuranceController : Controller
    {
        private readonly Repository<WealthInsurance, int> _wealthInsurance = new WealthInsuranceDAO();

        // GET: WealthInsurance
        public ActionResult Index()
        {
            var data = _wealthInsurance.findAll();
            return View(data);
        }

        // GET: WealthInsurance/Details/5
        public ActionResult Details(int id)
        {
            var data = _wealthInsurance.findById(id);
            return View(data);
        }

        // GET: WealthInsurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WealthInsurance/Create
        [HttpPost]
        public ActionResult Create(WealthInsurance collection)
        {
            try
            {
                var data = _wealthInsurance.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WealthInsurance/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _wealthInsurance.findById(id);
            return View(data);
        }

        // POST: WealthInsurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WealthInsurance collection)
        {
            try
            {
                collection.WealthInsuranceId = id;
                var data = _wealthInsurance.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WealthInsurance/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _wealthInsurance.findById(id);

            return View(data);
        }

        // POST: WealthInsurance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, WealthInsurance collection)
        {
            try
            {
                var data = _wealthInsurance.deleteByID(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
