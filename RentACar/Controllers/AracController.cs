using RentACar.Models;
using RentACar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using RentACar.Models.VM;
using RentACar.Filter;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace RentACar.Controllers
{
    [AutFilter]
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
        [AutFilter]
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
        [AutFilter]
        public ActionResult Create(Arac data)
        {
            #region Ekleme
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.Arac.Any(x => x.Plaka.Equals(data.Plaka) || x.SasiNo.Equals(data.SasiNo)))
                    {
                        return HttpNotFound("Bu kayıt zaten mevcut");
                    }
                    else
                    {
                        ar.Insert(data);
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
            Arac data = ar.SelectById(id);
            ViewBag.MarkaGetir = db.Marka.ToList();
            ViewBag.ModelGetir = db.Model.ToList();
            ViewBag.TipGetir = db.Tip.ToList();
            return View(data);
        }
        [HttpPost]
        [AutFilter]
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
        [AutFilter]
        public ActionResult Delete(int id, bool? savechangesError = false)
        {
            if (savechangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Silme işlemi başarısız.";
            }
            Arac secilenId = ar.SelectById(id);
            ar.Delete(id);
            return RedirectToAction("List", secilenId);
        }
        #endregion

        #region Dropdownliste model doldurma işlemi !!!
        [HttpPost]
        [AutFilter]
        public ActionResult Selected(int id)
        {
            List<Model> mdl = new List<Model>();
            foreach (var mdls in db.Model.Where(w => w.MarkaID == id).ToList())
            {
                mdl.Add(new Model() { ModelId = mdls.ModelId, ModelAdi = mdls.ModelAdi });
            }
            return Json(mdl, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PDF OLUŞTURMA !!!
        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime Time = DateTime.Now;
            //Dosya Adı oluşturulacak.
            string PdfDosyaAdi = string.Format("SamplePdf" + Time.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //5 sutunlu pdf oluşturma  
            PdfPTable tableLayout = new PdfPTable(8);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Pdf Tablo oluşturma
            //Dosya yolu 
            string PdfDosyaYolu = Server.MapPath("~/Downloadss/" + PdfDosyaAdi);

            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //PDF ye içerik eklenecek.   
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Belge kapatılacak.
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", PdfDosyaAdi);
        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 35, 35, 45, 35, 30, 40, 50, 45}; //Başlık genişliği kaç başlık olucaksa burada belirtiyoruz.
            tableLayout.SetWidths(headers); //pdf başlıklarını ayarla
            tableLayout.WidthPercentage = 100; //pdf dosyası eninde yüzde değeri ayarlanır. 
            tableLayout.HeaderRows = 1;
            
            //Üstteki pdf dosyasına başlık ekle

            List<Arac> Araclar = db.Arac.ToList<Arac>();



            tableLayout.AddCell(new PdfPCell(new Phrase("PDF DOSYASI", new Font(Font.FontFamily.HELVETICA, 24, 3, new iTextSharp.text.BaseColor(5, 5, 1))))
            {
                Colspan = 24,
                Border =5,
                PaddingBottom = 10,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            ////Başlık Ekle
            AddCellToHeader(tableLayout, "Arac");
            AddCellToHeader(tableLayout, "Marka");
            AddCellToHeader(tableLayout, "Model");
            AddCellToHeader(tableLayout, "SasiNo");
            AddCellToHeader(tableLayout, "Renk");
            AddCellToHeader(tableLayout, "Model Yılı");
            AddCellToHeader(tableLayout, "GunlukUcret");
            AddCellToHeader(tableLayout, "Birim");

            ////Add body  

            foreach (var arac in db.Arac)
            {


                AddCellToBody(tableLayout, arac.AracId.ToString());
                AddCellToBody(tableLayout, arac.Marka.MarkaAdi);
                AddCellToBody(tableLayout, arac.Model.ModelAdi);
                AddCellToBody(tableLayout, arac.SasiNo);
                AddCellToBody(tableLayout, arac.Renk);
                AddCellToBody(tableLayout, arac.ModelYıl);
                AddCellToBody(tableLayout, arac.GunlukUcret.ToString());
                AddCellToBody(tableLayout, arac.GunlukUcretBirimi);

            }

            return tableLayout;
        }
        // Başlıga Hücre ekleme yöntemi
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // İçeriğe Hücre ekleme Yöntemi
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }
        #endregion

        #region EXCEL OLUŞTURMA !!!
        public ActionResult ExportToExcel()
        {
            
                var gv = new GridView();
                gv.DataSource = ar.List();
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();
        
           
            return RedirectToAction("List");
        }
    }
    #endregion


}
