using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Repository
{
    public class ModelRepository : IRepository<Model>
    {
        AracTakipDBEntities db = new AracTakipDBEntities();
        public void Delete(object id)
        {
            db.Model.Remove(db.Model.Find(id));
            db.SaveChanges();
        }

        public void Insert(Model item)
        {
            db.Model.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Model> List()
        {
            return db.Model.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Model SelectById(int id)
        {
            return db.Model.Find(id);
        }

        public void Update(Model item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();   
        }
    }
}