using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Repository
{
    public class MusteriRepository : IRepository<Musteri>
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        public void Delete(object id)
        {
            db.Musteri.Remove(db.Musteri.Find(id));
            db.SaveChanges();
        }

        public void Insert(Musteri item)
        {
            db.Musteri.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Musteri> List()
        {
            return db.Musteri.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Musteri SelectById(int id)
        {
            return db.Musteri.Find(id);
        }

        public void Update(Musteri item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}