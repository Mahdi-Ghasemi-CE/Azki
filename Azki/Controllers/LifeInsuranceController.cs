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
    public class LifeInsuranceController : Controller
    {
        private readonly Repository<LifeInsurance, int> _repository = new LifeInsuranceDAO();
        // GET: LifeInsurance
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: LifeInsurance/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: LifeInsurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LifeInsurance/Create
        [HttpPost]
        public ActionResult Create(LifeInsurance collection)
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

        // GET: LifeInsurance/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: LifeInsurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LifeInsurance collection)
        {
            try
            {
                collection.LifeInsuranceId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LifeInsurance/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: LifeInsurance/Delete/5
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
