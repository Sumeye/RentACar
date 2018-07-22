using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RentACar.Repository
{
    public class AracRepository : IRepository<Arac>
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        public void Delete(object id)
        {
            db.Arac.Remove(db.Arac.Find(id));
            db.SaveChanges();
        }

        public void Insert(Arac item)
        {
            db.Arac.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Arac> List()
        {
            return db.Arac.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Arac SelectById(int id)
        {
            return db.Arac.Find(id);
        }

        public void Update(Arac item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}