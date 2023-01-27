using Azki.Data.Implements;
using Azki.Data.Interfaces;
using Azki.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;

namespace Azki.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly Repository<Insurance, int> _insurance = new InsuranceDAO();

        // GET: Insurance
        public ActionResult Index()
        {
            var data = _insurance.findAll();
            return View(data);
        }

        // GET: Insurance/Details/5
        public ActionResult Details(int id)
        {
            var data = _insurance.findById(id);
            return View(data);
        }

        // GET: Insurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurance/Create
        [HttpPost]
        public ActionResult Create(Insurance collection)
        {
            try
            {
                var data = _insurance.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insurance/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _insurance.findById(id);
            return View(data);
        }

        // POST: Insurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Insurance collection)
        {
            try
            {
                collection.InsuranceId = id;
                var data = _insurance.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insurance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insurance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var data = _insurance.deleteByID(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
