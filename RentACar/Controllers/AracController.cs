using RentACar.Models;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using RentACar.Models.VM;

namespace RentACar.Controllers
{
    public class AracController : Controller
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        AracRepository ar = new AracRepository();
        // GET: Arac
             #region Araç Listeleme !!!
        public ActionResult List()
        {
            var data = ar.List();
            return View(data);
        }
        #endregion

        #region Ekleme İşlemleri !!!
        public ActionResult Create()
        {
            ViewBag.MarkaGetir = db.Marka.ToList();
            ViewBag.ModelGetir = db.Model.ToList();
            ViewBag.TipGetir = db.Tip.ToList();
            //ViewBag.Marka = new SelectList(db.Marka, "MarkaId", "MarkaAdi");
            //ViewBag.Model = new SelectList(db.Model, "ModelId", "ModelAdi");
            //ViewBag.Tip = new SelectList(db.Tip, "TipId", "TipAdi");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Arac data)
        {
            #region Ekleme
            try
            {
                if (ModelState.IsValid)
                {
                    ar.Insert(data);
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Kayıt Eklenemedi");
            }
            return View(data);
            #endregion
        }
        #endregion

        #region Güncelleme İşlemleri !!!
        public ActionResult Edit(int id)
        {
            Arac data = ar.SelectById(id);
            ViewBag.MarkaGetir = db.Marka.ToList();
            ViewBag.ModelGetir = db.Model.ToList();
            ViewBag.TipGetir = db.Tip.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Arac data)
        {
            if (ModelState.IsValid)
            {
                ar.Update(data);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt hatası");
            }
            return View(data);
        }
        #endregion

        #region Silme işlemleri !!!
        public ActionResult Delete(int id, bool? savechangesError = false)
        {
            if (savechangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Silme işlemi başarısız.";
            }
            Arac category = ar.SelectById(id);
            ar.Delete(id);
            return RedirectToAction("List", category);
        }
        #endregion


    }
}