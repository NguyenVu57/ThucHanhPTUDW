using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class SuppliersDAO
    {
        private MyDBContext db = new MyDBContext();
        //SELECT * FROM
        public List<Suppliers> getList()
        {
            return db.Suppliers.ToList();
        }
        //SELECT * FROM cho INDEX chi voi status 1,2
        public List<Suppliers> getList(string status = "ALL")//status 0,1,2
        {
            List<Suppliers> list = null;
            switch (status)
            {
                case "Index": //1,2
                    {
                        list = db.Suppliers.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash": //0
                    {
                        list = db.Suppliers.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Suppliers.ToList();
                        break;
                    }
            }
            return list;
        }
        //detail
        public Suppliers getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Suppliers.Find(id);
            }
        }
        //create
        public int Insert(Suppliers row)
        {
            db.Suppliers.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Update(Suppliers row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(Suppliers row)
        {
            db.Suppliers.Remove(row);
            return db.SaveChanges();
        }
    }
}
