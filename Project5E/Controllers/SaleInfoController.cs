using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project5E.DAL;
using Project5E.DAL.Repository;

namespace Project5E.Controllers
{
    public class SaleInfoController : Controller
    {
        private IRepository<SaleInfo> _repository = null;

        public SaleInfoController()
        {
            this._repository = new Repository<SaleInfo>();
        }
        /*
        public ActionResult Index()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }*/
        
        public ActionResult Index(int managerid)
        {
            var employees = _repository.GetAll().Where(x => x.ManagerID == managerid).Select(x => x);
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SaleInfo item)
        {
            if (ModelState.IsValid)
            {
                item.SaleInfoID = _repository.GetAll().Last().SaleInfoID + 1;
                _repository.Insert(item);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }


        public ActionResult Edit(int Id)
        {
            var employee = _repository.GetById(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(SaleInfo item)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(item);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
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