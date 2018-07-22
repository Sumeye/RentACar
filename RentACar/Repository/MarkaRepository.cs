using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentACar.Repository
{
    public class MarkaRepository : IRepository<Marka>
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        public void Delete(object id)
        {
            db.Marka.Remove(db.Marka.Find(id));
            db.SaveChanges();
        }
        public void Insert(Marka item)
        {
            db.Marka.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Marka> List()
        {
            return db.Marka.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Marka SelectById(int id)
        {
            return db.Marka.Find(id);
        }

        public void Update(Marka item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}