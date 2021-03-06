﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using enrollmentApplication.Models;

namespace enrollmentApplication.Controllers
{
    public class EnrollmentController : Controller
    {
        private enrollmentApplicationdb db = new enrollmentApplicationdb();

        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        public ActionResult StudentSearch(string q)
        {
            var student = GetStudent(q);
            return PartialView(student);
        }

        private List<Student> GetStudent(string searchString)
        {
            return db.Students.Where(a => a.studentFirstName.Contains(searchString) || a.studentLastName.Contains(searchString)).ToList();

        }

        public ActionResult CourseSearch(string q)
        {
            var course = GetCourse(q);
            return PartialView(course);
        }

        private List<Course> GetCourse(string searchString)
        {
            return db.Courses.Where(a => a.courseTitle.Contains(searchString)).ToList();
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseTitle");
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentLastName");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enrollmentID,studentID,courseID,grade,Notes,Address1,Address2,City,State,Zipcode,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseTitle", enrollment.courseID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentLastName", enrollment.studentID);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseTitle", enrollment.courseID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentLastName", enrollment.studentID);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enrollmentID,studentID,courseID,grade,Notes,Address1,Address2,City,State,Zipcode,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseTitle", enrollment.courseID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentLastName", enrollment.studentID);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
