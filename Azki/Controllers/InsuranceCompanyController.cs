using Azki.Data;
using Azki.Data.Implements;
using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Azki.Controllers
{
    public class InsuranceCompanyController : Controller
    {
        private readonly Repository<InsuranceCompany, int> _insuranceCompany = new InsuranceCompanyDAO();

        // GET: InsuranceCompany
        public ActionResult Index()
        {
            var data = _insuranceCompany.findAll();
            return View(data);
        }

        // GET: InsuranceCompany/Details/5
        public ActionResult Details(int id)
        {
            var data = _insuranceCompany.findById(id);

            return View(data);
        }

        // GET: InsuranceCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceCompany/Create
        [HttpPost]
        public ActionResult Create(InsuranceCompany collection)
        {
            try
            {
                var res = _insuranceCompany.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: InsuranceCompany/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceCompany/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, InsuranceCompany collection)
        {
            try
            {
                collection.InsuranceCompanyId = id;
                var res = _insuranceCompany.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InsuranceCompany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceCompany/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, InsuranceCompany collection)
        {
            try
            {
                var res = _insuranceCompany.deleteByID(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
