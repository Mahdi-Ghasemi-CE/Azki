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
    public class SicknessCoverageTypesController : Controller
    {
        private readonly Repository<SicknessCoverageType, int> _repository = new SicknessCoverageTypesDAO();
        // GET: SicknessCoverageTypes
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: SicknessCoverageTypes/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: SicknessCoverageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SicknessCoverageTypes/Create
        [HttpPost]
        public ActionResult Create(SicknessCoverageType collection)
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

        // GET: SicknessCoverageTypes/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: SicknessCoverageTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SicknessCoverageType collection)
        {
            try
            {
                collection.SicknessCoverageTypesId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SicknessCoverageTypes/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: SicknessCoverageTypes/Delete/5
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
