using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Human
    {
        public int id {get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public byte Age { get; set;}
        public string NationalCode { get; set;}

        public db humandb = new db();
        public bool register (Human h)
        {
            if (!exist(h))
            {
                humandb.humans.Add(h);
                humandb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool exist (Human h)
        {
            var a = humandb.humans.Where(i=> i.NationalCode == h.NationalCode).ToList();
            if (a.Count==1)
            {
                return true;
            }
            else { return false; }
        }

        public List<Human> readname(string name)
        {
            return humandb.humans.Where(i=> i.FirstName.Contains(name) || i.LastName.Contains(name)).ToList();
        }

        public List<Human> readnc (string nc)
        {
            return humandb.humans.Where(i=> Convert.ToString(i.NationalCode).Contains(nc)).ToList();
        }

        public List<Human> readall()
        {
            return humandb.humans.ToList();
        }

        public void delete(int id)
        {
            Human h = humandb.humans.Where(i=> i.id == id).FirstOrDefault();
            if (h != null)
            {
                humandb.humans.Remove(h);
                humandb.SaveChanges();
            }
        }
        public void update(Human h, int id)
        {
            var a = humandb.humans.Where(i=>i.id == id).FirstOrDefault();
            a.FirstName = h.FirstName;
            a.LastName = h.LastName;
            a.Age = h.Age;
            a.NationalCode = h.NationalCode;
            humandb.SaveChanges();
        }
    }
}
