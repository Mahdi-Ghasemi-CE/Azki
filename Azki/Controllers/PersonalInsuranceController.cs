using Azki.Data.Implements;
using Azki.Data.Interfaces;
using Azki.Data;
using System.Web.Mvc;

namespace Azki.Controllers
{
    public class PersonalInsuranceController : Controller
    {
        private readonly Repository<PersonalInsurance, int> _repository = new PersonalInsuranceDAO();
        // GET: PersonalInsurance
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: PersonalInsurance/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: PersonalInsurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalInsurance/Create
        [HttpPost]
        public ActionResult Create(PersonalInsurance collection)
        {
            try
            {
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalInsurance/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: PersonalInsurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonalInsurance collection)
        {
            try
            {
                collection.PersonalInsuranceId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalInsurance/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: PersonalInsurance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var data = _repository.deleteByID(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
