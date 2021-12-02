using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_btl.Areas.Admin.Models;


namespace mvc_btl.Areas.Admin.Controllers
{
    public class TACGIAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/TACGIAs
        public ActionResult Index()
        {
            return View();
            //var tacgias = db.TACGIAs.Select(p => p);
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    tacgias = tacgias.Where(p => p.Quequan.Contains(searchString));
            //}
           
            //return View(tacgias.ToList());
           
        }

        // GET: Admin/TACGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIAs.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // GET: Admin/TACGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TACGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTG,TenTG,Anh,Ngaysinh,Quequan,Tieusu")] TACGIA tACGIA)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    tACGIA.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        //Use  Namespace  called  :	System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        //Lấy  tên  file  upload
                        string UploadPath = Server.MapPath("~/Areas/Asset/images/" + FileName);
                        //Copy  Và  lưu  file  vào  server.
                        f.SaveAs(UploadPath);
                        //Lưu  tên  file  vào  trường
                        tACGIA.Anh = FileName;
                    }
                    db.TACGIAs.Add(tACGIA);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                return View(tACGIA);
            }
            
        }

        // GET: Admin/TACGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIAs.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // POST: Admin/TACGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTG,TenTG,Anh,Ngaysinh,Quequan,Tieusu")] TACGIA tACGIA)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        //Use  Namespace  called  :	System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        //Lấy  tên  file  upload
                        string UploadPath = Server.MapPath("~/Areas/Asset/images/" + FileName);
                        //Copy  Và  lưu  file  vào  server.
                        f.SaveAs(UploadPath);
                        //Lưu  tên  file  vào  trường
                        tACGIA.Anh = FileName;
                    }
                    db.Entry(tACGIA).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Nhập thông tin lỗi" + ex.Message;
                return View(tACGIA);
            }
        }

        // GET: Admin/TACGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIAs.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // POST: Admin/TACGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TACGIA tACGIA = db.TACGIAs.Find(id);
            db.TACGIAs.Remove(tACGIA);
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
