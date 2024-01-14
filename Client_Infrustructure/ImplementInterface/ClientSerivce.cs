using Client_ApplicationCore.Interface;
using Client_Infrustructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Infrustructure.ImplementInterface
{
    public class ClientSerivce : IClient<Client>
    {
        ClientDBContext db;
        public ClientSerivce(ClientDBContext _db)
        {
            db = _db;
        }
        public void Add(Client entiy)
        {
            db.Clients.Add(entiy);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var client = Find(Id);
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        public Client Find(int Id)
        {
            var query = db.Clients.SingleOrDefault(b => b.Id == Id);
            return query;
        }

        public IList<Client> List()
        {
            return db.Clients.ToList();
        }

        public List<Client> Search(string valueSearch)
        {
            //return db.Clients.Where(x => x.FirstName.Contains("valueSearch") ||x.Email.Contains("valueSearch")||
            //x.MobileNumber.Contains("valueSearch")).ToList();

            var clients = db.Clients.FromSqlRaw($"GetAllClients {valueSearch}").ToList();
            return clients;
        }

        public void Update(Client entity)
        {
            db.Clients.Update(entity);
            db.SaveChanges();
        }
    }
}
