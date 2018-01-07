using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project5E.DAL.Repository;
using Project5E.DAL;

namespace Project5E.Controllers
{
    public class ManagerController : Controller
    {
        private IRepository<Manager> _repository = null;

        public ManagerController()
        {
            this._repository = new Repository<Manager>();
        }

        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Manager employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }


        public ActionResult Edit(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Manager employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(employee);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        public ActionResult Details(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }

        public ActionResult Delete(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var employee = _repository.GetById(Id);
            _repository.Delete(Id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}