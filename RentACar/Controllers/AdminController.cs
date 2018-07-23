using RentACar.Models;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        AdminRepository ar = new AdminRepository();

        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin item)
        {
            using (AracTakipDBEntities db = new AracTakipDBEntities())
            {

                var find = (from a in db.Admin
                            where a.UserName.ToLower().Trim() == item.UserName.ToLower().Trim() &&
                                  a.Password.ToLower().Trim() == item.Password.ToLower().Trim()
                            select a).FirstOrDefault();
                if (find != null)
                {
                    Session["AdminId"] = find.AdminId;
                    Session["UserName"] = find.UserName;
                    return RedirectToAction("List","Arac");
                }
                else
                {
                    return View(item);
                }
            }
        }



        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Admin item)
        {
            Admin a = new Admin();
            using (AracTakipDBEntities db = new AracTakipDBEntities())
            {
               
                a.UserName =item.UserName;
                a.Password = item.Password;
                db.Admin.Add(a);
                db.SaveChanges();

            }
            return RedirectToAction("Login", "Admin");
        }


       
      

        #region Kullanıcıların Listelenmesi !!!
        public ActionResult List()
        {
            var data = ar.List();
            return View(data);
        }
        #endregion



     
       

        #region Güncelleme İşlemleri !!!
        public ActionResult Edit(int id)
        {
            Admin data = ar.SelectById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Admin data)
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
            Admin SecilenId = ar.SelectById(id);
            ar.Delete(id);
            return RedirectToAction("List", SecilenId);
        }
        #endregion

    }
}