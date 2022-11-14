using System.Collections.Generic;
using System.Linq;
using ClientsMVC.Models;
using ClientsMVC.Models.EntityFramework;
using ClientsMVC.Repositories.ClientRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientsMVC.Repositories.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext context;

        public ClientRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Client> GetAll()
        {
            return context.Clients.Include(x => x.Adressess).ToList();
        }

        public int Add(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
            return client.Id;
        }

        public void AddRange(List<Client> clients)
        {
            context.Clients.AddRange(clients);
            context.SaveChanges();
        }
    }
}
