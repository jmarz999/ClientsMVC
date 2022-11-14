using System.Collections.Generic;
using ClientsMVC.Models;

namespace ClientsMVC.Repositories.ClientRepository.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        int Add(Client client);
        void AddRange(List<Client> clients);
    }
}