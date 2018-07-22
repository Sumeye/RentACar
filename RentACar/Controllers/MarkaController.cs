using RentACar.Models;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class MarkaController : Controller
    {
        MarkaRepository mr = new MarkaRepository();
        // GET: Marka
        public ActionResult Index()
        {
            return View();
        }

        #region Marka Listeleme !!!
        public ActionResult List()
        {
            var data = mr.List();
            return View(data);
        }
        #endregion

        #region Ekleme İşlemleri !!!
        public ActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(Marka data)
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
            Marka brand = mr.SelectById(id);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(Marka brand)
        {
            if (ModelState.IsValid)
            {
                mr.Update(brand);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt hatası");
            }
            return View(brand);
        }
        #endregion

        #region Silme işlemleri !!!
        public ActionResult Delete(int id, bool? savechangesError = false)
        {
            if (savechangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Silme işlemi başarısız.";
            }
            Marka category = mr.SelectById(id);
            mr.Delete(id);
            return RedirectToAction("List", category);
        } 
        #endregion

    }
}