using Microsoft.EntityFrameworkCore;
using skeleton.Data;
using skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Repositories
{
    public class ClientRepository : IClientRepository
    {

        public ClientRepository()
        {
            using var context = new APIDbContext();
          if(  context == null)  throw new ArgumentNullException(nameof(context));
      
        }
        public async Task<IEnumerable<Client>> GetClients()
        {
            using (var context = new APIDbContext())
            {
                return await context.Clients.ToListAsync();
            }
        }
        public async Task<Client> GetClientByID(int ID)
        {
            using (var context = new APIDbContext())
            {
                return await context.Clients.FindAsync(ID);
            }
        }
        public async Task<Client> InsertClient(Client objClient)
        {
            using (var context = new APIDbContext())
            {
                context.Clients.Add(objClient);
                await context.SaveChangesAsync();
                return objClient;
            }
        }
        public async Task<Client> UpdateClient(Client objClient)
        {
            using (var context = new APIDbContext())
            {
                context.Entry(objClient).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return objClient;
            }
        }
        public bool DeleteClient(int ID)
        {
                using (var context = new APIDbContext())
                {
                    bool result = false;
            var department = context.Clients.Find(ID);
            if (department != null)
            {
                    context.Entry(department).State = EntityState.Deleted;
                    context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
                }
    }
}
