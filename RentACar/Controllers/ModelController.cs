using RentACar.Filter;
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
    public class ModelController : Controller
    {
        ModelRepository mr = new ModelRepository();
        AracTakipDBEntities db = new AracTakipDBEntities();
        // GET: Model
        #region Model tablosunu Listeler !!
        [AutFilter]
        public ActionResult List()
        {
            var data = mr.List();
            return View(data);
        }
        #endregion

        #region Model tablosu Ekleme İşlemleri !!!
        [AutFilter]
        public ActionResult Create()
        {
            ViewBag.MarkaGetir = db.Marka.ToList();
            return View();
        }
        [HttpPost]
        [AutFilter]
        public ActionResult Create(Model data)
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

        #region Model tablosu Güncelleme İşlemleri !!!
        [AutFilter]
        public ActionResult Edit(int id)
        {
           
            Model model = mr.SelectById(id);
            ViewBag.MarkaGetir = db.Marka.ToList();
            return View(model);
        }
        [HttpPost]
        [AutFilter]
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                mr.Update(model);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt hatası");
            }
            return View(model);
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
            Model category = mr.SelectById(id);
            mr.Delete(id);
            return RedirectToAction("List", category);
        }
        #endregion


    }
}