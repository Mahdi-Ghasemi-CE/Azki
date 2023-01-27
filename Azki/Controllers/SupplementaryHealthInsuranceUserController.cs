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
    public class SupplementaryHealthInsuranceUserController : Controller
    {
        private readonly Repository<SupplementaryHealthInsuranceUser, int> _repository = new SupplementaryHealthInsuranceUserDAO();
        // GET: SupplementaryHealthInsuranceUser
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: SupplementaryHealthInsuranceUser/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: SupplementaryHealthInsuranceUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplementaryHealthInsuranceUser/Create
        [HttpPost]
        public ActionResult Create(SupplementaryHealthInsuranceUser collection)
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

        // GET: SupplementaryHealthInsuranceUser/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: SupplementaryHealthInsuranceUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SupplementaryHealthInsuranceUser collection)
        {
            try
            {
                collection.SupplementaryHealthInsuranceUserId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplementaryHealthInsuranceUser/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: SupplementaryHealthInsuranceUser/Delete/5
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
