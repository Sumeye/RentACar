using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Repository
{
    public class RezervasyonRepository : IRepository<Rezervasyon>
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        public void Delete(object id)
        {
            db.Rezervasyon.Remove(db.Rezervasyon.Find(id));
            db.SaveChanges();
        }

        public void Insert(Rezervasyon item)
        {
            db.Rezervasyon.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Rezervasyon> List()
        {
          return  db.Rezervasyon.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Rezervasyon SelectById(int id)
        {
            return db.Rezervasyon.Find(id);
        }

        public void Update(Rezervasyon item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }
    }
}