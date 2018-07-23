using RentACar.Models;
using RentACar.Models.VM;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class RezervasyonController : Controller
    {
        RezervasyonRepository repo = new RezervasyonRepository();
        AracTakipDBEntities db = new AracTakipDBEntities();
        // GET: Rezervasyon
        #region Rezervasyon Listeleme İşlemleri
        public ActionResult List()
        {
            var data = repo.List();
            return View(data);
        } 
        #endregion

        #region Rezervasyon Ekleme işlemleri !!!
        public ActionResult Create()
        {
            ViewBag.MusteriGetir = db.Musteri.ToList();
            ViewBag.AracGetir = db.Arac.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rezervasyon data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Insert(data);
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Kayıt başarısız");

            }
            return View(data);

        }
        #endregion



        #region Güncelleme İşlemleri !!!
        public ActionResult Edit(int id)
        {
            Rezervasyon data = repo.SelectById(id);
            ViewBag.MusteriGetir = db.Musteri.ToList();
            ViewBag.AracGetir = db.Arac.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Rezervasyon data)
        {
            if (ModelState.IsValid)
            {
                repo.Update(data);
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
            Rezervasyon rezerve = repo.SelectById(id);
            repo.Delete(id);
            return RedirectToAction("List", rezerve);
        }
        #endregion
    }
}