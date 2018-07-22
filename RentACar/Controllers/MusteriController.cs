using RentACar.Models;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace RentACar.Controllers
{
    public class MusteriController : Controller
    {
        MusteriRepository mr = new MusteriRepository();

        AracTakipDBEntities db = new AracTakipDBEntities();
        // GET: Customer
        #region Müşteri tablosu Listeleme !!
        public ActionResult List()
        {
            var data = mr.List();
            return View(data);
        }
        #endregion

        #region Ekleme İşlemleri !!!
        public ActionResult Create()
        {
            ViewBag.ilgetir = db.iller.ToList();
            ViewBag.ilcegetir = db.ilceler.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteri data)
        {
            #region Ekleme
            try
            {
                if (ModelState.IsValid)
                {
                    mr.Insert(data);
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
            ViewBag.ilgetir = db.iller.ToList();
            ViewBag.ilcegetir = db.ilceler.ToList();
            Musteri data = mr.SelectById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Musteri data)
        {
            if (ModelState.IsValid)
            {
                mr.Update(data);
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
            Musteri category = mr.SelectById(id);
            mr.Delete(id);
            return RedirectToAction("List", category);
        }
        #endregion


    }
}