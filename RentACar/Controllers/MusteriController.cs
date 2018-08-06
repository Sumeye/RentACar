using RentACar.Models;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using RentACar.Filter;

namespace RentACar.Controllers
{
    public class MusteriController : Controller
    {
        MusteriRepository mr = new MusteriRepository();

        AracTakipDBEntities db = new AracTakipDBEntities();
        // GET: Customer
        #region Müşteri tablosu Listeleme !!
        [AutFilter]
        public ActionResult List()
        {
            var data = mr.List();
            return View(data);
        }
        #endregion

        #region Ekleme İşlemleri !!!
        [AutFilter]
        public ActionResult Create()
        {
            ViewBag.ilgetir = db.iller.ToList();
            ViewBag.ilcegetir = db.ilceler.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteri data)
        {

            int ilkonsayi = 0;
            int toplam = 0;
            foreach (char No in data.Tc)
            {
                if (ilkonsayi < 10)
                {
                    toplam += Convert.ToInt32(char.ToString(No));
                }
                ilkonsayi++;
            }

            #region Ekleme
            try
            {
                if (ModelState.IsValid)
                {
                    if (toplam % 10 == Convert.ToUInt32(data.Tc[10].ToString()))
                    {
                        if (db.Musteri.Any(x => x.Tc.Equals(data.Tc) || x.VergiNo.Equals(data.VergiNo)))
                        {

                            return HttpNotFound("Bu Kayıt Zaten Mevcut");//TODO: Mesaj  düzenlenecek.
                        }
                        else
                        {
                            mr.Insert(data);

                        }
                    }
                    else
                    {
                        return HttpNotFound("Geçerli bir TC kimlin numarası giriniz");//TODO:Mesaj düzenlenecek.
                    }
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
        [AutFilter]
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
        [AutFilter]
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


        #region İlce Doldurma Methodu !!!
        [HttpPost]
        [AutFilter]
        public ActionResult Selected(int id)
        {
            List<ilceler> ilce = new List<ilceler>();
            foreach (var ilcedata in db.ilceler.Where(w => w.sehirID == id).ToList())
            {
                ilce.Add(new ilceler() { ilceId = ilcedata.ilceId, ilce = ilcedata.ilce });
            }
            return Json(ilce, JsonRequestBehavior.AllowGet);
        }

        #endregion





    }
}