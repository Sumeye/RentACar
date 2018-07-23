using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Repository
{
    public class AdminRepository : IRepository<Admin>
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        public void Delete(object id)
        {
            db.Admin.Remove(db.Admin.Find(id));
            db.SaveChanges();
        }

        public void Insert(Admin item)
        {
            db.Admin.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Admin> List()
        {
            return db.Admin.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Admin SelectById(int id)
        {
            return db.Admin.Find(id);
        }

        public void Update(Admin item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}