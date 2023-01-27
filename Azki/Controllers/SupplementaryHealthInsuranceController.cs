using Azki.Data.Implements;
using Azki.Data.Interfaces;
using Azki.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Azki.Controllers
{
    public class SupplementaryHealthInsuranceController : Controller
    {
        private readonly Repository<SupplementaryHealthInsurance, int> _repository = new SupplementaryHealthInsuranceDAO();
        // GET: SupplementaryHealthInsurance
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: SupplementaryHealthInsurance/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: SupplementaryHealthInsurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplementaryHealthInsurance/Create
        [HttpPost]
        public ActionResult Create(SupplementaryHealthInsurance collection)
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

        // GET: SupplementaryHealthInsurance/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: SupplementaryHealthInsurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SupplementaryHealthInsurance collection)
        {
            try
            {
                collection.SupplementaryHealthInsuranceId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplementaryHealthInsurance/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: SupplementaryHealthInsurance/Delete/5
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
