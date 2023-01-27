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
    public class PaiedInsuranceController : Controller
    {
        private readonly Repository<PaiedInsurance, int> _repository = new PaiedInsuranceDAO();

        // GET: PaiedInsurance
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: PaiedInsurance/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: PaiedInsurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaiedInsurance/Create
        [HttpPost]
        public ActionResult Create(PaiedInsurance collection)
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

        // GET: PaiedInsurance/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: PaiedInsurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaiedInsurance collection)
        {
            try
            {
                collection.PaiedInsuranceId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PaiedInsurance/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: PaiedInsurance/Delete/5
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
