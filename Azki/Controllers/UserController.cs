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
    public class UserController : Controller
    {
        private readonly Repository<User, int> _user = new UsersDAO();

        // GET: User
        public ActionResult Index()
        {
            var data = _user.findAll();
            return View(data);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var data = _user.findById(id);
            return View(data);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User collection)
        {
            try
            {
                var data = _user.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _user.findById(id);
            return View(data);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                collection.UserId = id;
                var data = _user.save(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _user.findById(id);
            return View(data);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                collection.UserId = id;
                var data = _user.deleteByID(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
