using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Book.Models;

namespace Web_Book.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome!";
            return View();
        }

        public ActionResult Add_Book()
        {
            return View(new ListBookModel());
        }

        [HttpPost]
        public ActionResult Add_Book(ListBookModel model)
        {
            if (!TryUpdateModel(model))
            {
                return View(model);
            }

            BookDataStorage.Instance.AddBook(model);
            return View("About",model);
        }

        public ActionResult List_Book()
        {
            return View(BookDataStorage.Instance.GetAllBooks().OrderBy(x=>x.Id));
        }

        public ActionResult About(int id)
        {
            return View(BookDataStorage.Instance.GetBookByBookId(id));
        }

        public ActionResult Edit(int id)
        {
            return View(BookDataStorage.Instance.GetBookByBookId(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ListBookModel model)
        {
            if (!TryUpdateModel(model))
            {
                return View(model);
            }
            BookDataStorage.Instance.UpdateBook(model);
            return View("About", model);
        }

        public ActionResult Delete(int id)
        {
            return View(BookDataStorage.Instance.GetBookByBookId(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            BookDataStorage.Instance.DeleteBook(id);
            return RedirectToAction("List_Book");
        }
    }
}