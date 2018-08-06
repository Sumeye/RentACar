using RentACar.Filter;
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
        [AutFilter]
        public ActionResult List()
        {
            var data = repo.List();
            return View(data);
        }
        #endregion
        #region Rezervasyon Ekleme işlemleri !!!
        [AutFilter]
        public ActionResult Create()
        {
            ViewBag.MusteriGetir = db.Musteri.ToList();
            ViewBag.AracGetir = db.Arac.ToList();
            return View();
        }
        [HttpPost]
        [AutFilter]
        public ActionResult Create(Rezervasyon data)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (db.Arac.Any(x => x.AracId == data.AracID))
                    {
                        if (db.Rezervasyon.Any(x => x.RezerveTarih == data.RezerveTarih && x.RezerveBitisTarihi == data.RezerveBitisTarihi))
                        {
                            return HttpNotFound("Bu tarih aralığında araç zaten kiralanmıştır.");
                        }
                    }
                    else
                    {
                        repo.Insert(data);
                    }
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
        [AutFilter]
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
        //[AutFilter]
        //public ActionResult Delete(int id, bool? savechangesError = false)
        //{
        //    if (savechangesError.GetValueOrDefault())
        //    {
        //        ViewBag.ErrorMessage = "Silme işlemi başarısız.";
        //    }
        //    Rezervasyon rezerve = repo.SelectById(id);
        //    repo.Delete(id);
        //    return RedirectToAction("List", rezerve);
        //}
        #endregion
        #region JQuery ile Silme İşlemi !!!
        [AutFilter]
        public JsonResult DeleteReservation(int id)
        {
            Rezervasyon deletereservation = repo.SelectById(id);
            if (deletereservation != null)
            {

                repo.Delete(id);
                return Json("Silme işlemi başarıyla gerçekleşti.", JsonRequestBehavior.AllowGet);
            }
            return Json("Silme işlemi gerçekleşmedi.", JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region JQuery ile Rezervasyon Arama İşlemi !!!
        [HttpPost]
        [AutFilter]
        public ActionResult ReservationSearch(DateTime StartDate, DateTime EndDate)
        {
            var RezerveList = db.sp_ReservationList(StartDate.Date, EndDate.Date);
            return Json(RezerveList, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
