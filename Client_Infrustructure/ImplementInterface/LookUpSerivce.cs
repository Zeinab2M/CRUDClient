using Client_ApplicationCore.Interface;
using Client_Infrustructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Infrustructure.ImplementInterface
{
    public class LookUpSerivce : ILookUp<LookUp>
    {
        ClientDBContext db;
        public LookUpSerivce(ClientDBContext _db)
        {
            db = _db;
        }
        public void Add(LookUp entiy)
        {
            db.LookUps.Add(entiy);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var lookUp = Find(Id);
            db.LookUps.Remove(lookUp);
            db.SaveChanges();
        }

        public LookUp Find(int? Id)
        {
            var query = db.LookUps.SingleOrDefault(b => b.Id == Id);
            return query;
        }

        public IList<LookUp> List()
        {
            return db.LookUps.ToList();
        }

        public List<LookUp> Search(string valueSearch)
        {
            return db.LookUps.Where(x => x.Status.Contains("valueSearch")).ToList();
        }

        public void Update(LookUp entity)
        {
            db.LookUps.Update(entity);
            db.SaveChanges();
        }
    }
}
