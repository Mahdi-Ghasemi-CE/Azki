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
    public class SicknessCoverageController : Controller
    {
        private readonly Repository<SicknessCoverage, int> _repository = new SicknessCoverageDAO();
        // GET: SicknessCoverage
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: SicknessCoverage/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: SicknessCoverage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SicknessCoverage/Create
        [HttpPost]
        public ActionResult Create(SicknessCoverage collection)
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

        // GET: SicknessCoverage/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: SicknessCoverage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SicknessCoverage collection)
        {
            try
            {
                collection.SicknessCoverageId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SicknessCoverage/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: SicknessCoverage/Delete/5
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
