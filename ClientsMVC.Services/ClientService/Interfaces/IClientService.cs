using System.Collections.Generic;
using ClientsMVC.Services.ClientService.Dto;

namespace ClientsMVC.Services.ClientService.Interfaces
{
    public interface IClientService
    {
        List<ClientDto> GetAll();
        void Add(CreateClientDto client);
        void ImportClients(List<ClientsClient> clients);
    }
}