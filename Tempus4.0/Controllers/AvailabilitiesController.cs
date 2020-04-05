using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tempus4._0.Models;

namespace Tempus4._0.Controllers
{
    [Authorize(Roles="Supervisor")]
    public class AvailabilitiesController : Controller
    {
        private Tempus2_DBEntities db = new Tempus2_DBEntities();

        // GET: Availabilities
        public async Task<ActionResult> Index()
        {
            var availabilities = db.Availabilities.Include(a => a.Employee).Include(a => a.Job).Include(a => a.Administrator);
            return View(await availabilities.ToListAsync());
        }

        // GET: Availabilities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = await db.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // GET: Availabilities/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName");
            ViewBag.JobID = new SelectList(db.Jobs, "jobID", "Title");
            ViewBag.AdministratorsId = new SelectList(db.Administrators, "Id", "First_Name");
            return View();
        }

        // POST: Availabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AvailabilityID,Date,JobID,EmployeeID,AdministratorsId")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                db.Availabilities.Add(availability);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", availability.EmployeeID);
            ViewBag.JobID = new SelectList(db.Jobs, "jobID", "Title", availability.JobID);
            ViewBag.AdministratorsId = new SelectList(db.Administrators, "Id", "First_Name", availability.AdministratorsId);
            return View(availability);
        }

        // GET: Availabilities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = await db.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", availability.EmployeeID);
            ViewBag.JobID = new SelectList(db.Jobs, "jobID", "Title", availability.JobID);
            ViewBag.AdministratorsId = new SelectList(db.Administrators, "Id", "First_Name", availability.AdministratorsId);
            return View(availability);
        }

        // POST: Availabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AvailabilityID,Date,JobID,EmployeeID,AdministratorsId")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availability).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", availability.EmployeeID);
            ViewBag.JobID = new SelectList(db.Jobs, "jobID", "Title", availability.JobID);
            ViewBag.AdministratorsId = new SelectList(db.Administrators, "Id", "First_Name", availability.AdministratorsId);
            return View(availability);
        }

        // GET: Availabilities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = await db.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // POST: Availabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Availability availability = await db.Availabilities.FindAsync(id);
            db.Availabilities.Remove(availability);
            await db.SaveChangesAsync();
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
