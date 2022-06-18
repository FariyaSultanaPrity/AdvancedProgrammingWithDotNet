using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAll.EF;


namespace TestAll.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            DotNetTestEntities db = new DotNetTestEntities();
            var data = db.Students.ToList();
            return View(data);
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {

            if (ModelState.IsValid)
            {
                DotNetTestEntities db = new DotNetTestEntities();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]

        public ActionResult Edit(int id)
        {
            
            DotNetTestEntities db = new DotNetTestEntities();
            var data = (from b in db.Students
                        where b.Serial == id
                        select b).SingleOrDefault();
            db.SaveChanges();
            return View(data);
            
        }
        [HttpPost]
        public ActionResult Edit(Student s1)
        {

            DotNetTestEntities db = new DotNetTestEntities();
            var data = (from p in db.Students where p.Id == s1.Id select p).FirstOrDefault();

            data.Name = s1.Name;
            data.Dob = s1.Dob;
            data.Email = s1.Email;
            data.Id = s1.Id;
            data.Dept = s1.Dept;
            data.Gender = s1.Gender;
            


            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException s)
            {
                return View(s1);
            }


        }

        public ActionResult Delete(int id)
        {
            DotNetTestEntities db = new DotNetTestEntities();
            var st = (from s in db.Students where s.Serial==id  select s).SingleOrDefault();
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}