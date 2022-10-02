using BusinessLayer.Concrete;

using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace ProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm= new WriterManager(new EfWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
           string  p = (string)Session["WriterMail"];
            ViewBag.d = p;
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            
            var writervalue = wm.GetByID(id);
            //ViewBag.a = id;
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("MyHeading", "WriterPanel");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(int id=1)

        {
            

            var values = hm.GetListByWriter(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 4;
            hm.HeadingAddBL(p);
            return RedirectToAction("MyHeading");
           
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]

        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }
    }
}