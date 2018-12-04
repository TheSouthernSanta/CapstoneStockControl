using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class ItemsController : Controller
    {
        private DB db = new DB();

        // GET: Items
        public ActionResult Index(OrderBy order = OrderBy.UseBy)
        {
                switch (order)
                {
                    case OrderBy.None:
                        return View(db.Item.Where(x => x.IsDeleted == false).ToList());

                    case OrderBy.Name:
                        return View(db.Item.Where(x => x.IsDeleted == false).ToList().OrderBy(x => x.Name).ToList());

                    case OrderBy.UseBy:
                        return View(db.Item.Where(x => x.IsDeleted == false).ToList().OrderBy(x => x.UseBy).ToList());

                    case OrderBy.Quantity:
                        return View(db.Item.Where(x => x.IsDeleted == false).ToList().OrderBy(x => x.Quantity).ToList());

                    case OrderBy.BaseQuantity:
                        return View(db.Item.Where(x => x.IsDeleted == false).ToList().OrderBy(x => x.BaseQuantity).ToList());
                }
            return Content("An error occurred");
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Item.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        public ActionResult Searchby(string attrib, string value)
        {
            IEnumerable<Items> theList;

            using (DB context = new DB())
            {
                switch (attrib)
                {
                    case "UseBy":
                        var date = DateTime.Parse(value);
                        theList = context.Item
                           .Where(h => h.UseBy == date)
                           .ToList();
                        break;

                    case "Name":
                        theList = context.Item
                           .Where(x => x.Name == value)
                           .ToList();
                        break;

                    default:
                        return Content("Not found");
                }
                return View("Index", theList);
            }
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Items items)
        {
            if (ModelState.IsValid)
            {
                items.CreationDate = DateTime.Now;
                db.Item.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(items);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Item.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AmmountInKgs,Supplier,UseBy,LowerThreshhold")] Items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Item.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }

            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Items items = db.Item.Find(id);
            items.IsDeleted = true;
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
