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
    public class ReminderController : Controller
    {
        private readonly Repository<Reminder, int> _repository = new ReminderDAO();
        // GET: Reminder
        public ActionResult Index()
        {
            var data = _repository.findAll();
            return View(data);
        }

        // GET: Reminder/Details/5
        public ActionResult Details(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // GET: Reminder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reminder/Create
        [HttpPost]
        public ActionResult Create(Reminder collection)
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

        // GET: Reminder/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _repository.findById(id);
            return View(data);
        }

        // POST: Reminder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Reminder collection)
        {
            try
            {
                collection.ReminderId = id;
                var data = _repository.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reminder/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _repository.findById(id);
            return View();
        }

        // POST: Reminder/Delete/5
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
