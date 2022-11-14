using System.Collections.Generic;
using System.Linq;
using ClientsMVC.Models;
using ClientsMVC.Repositories.AddressRepository.Interfaces;
using ClientsMVC.Repositories.ClientRepository.Interfaces;
using ClientsMVC.Services.ClientService.Dto;
using ClientsMVC.Services.ClientService.Interfaces;

namespace ClientsMVC.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IAddressRepository addressRepository;

        public ClientService(IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            this.clientRepository = clientRepository;
            this.addressRepository = addressRepository;
        }

        public List<ClientDto> GetAll()
        {
            var clients = clientRepository.GetAll();
            return clients.Select(x => x.EntityToDto()).ToList();
        }

        public void Add(CreateClientDto client)
        {
            var clientEntity = client.DtoToEntity();

            _ = clientRepository.Add(clientEntity);
        }

        public void ImportClients(List<ClientsClient> clients)
        {
            foreach (var item in clients)
            {
                var client = new ClientDto()
                {
                    Id = item.ID,
                    Name = item.Name,
                    BirthDate = System.DateTime.Parse(item.BirthDate),
                    Addressess = item.Addresses.Select(x => new AddressDto
                    {
                        Name = x.Value,
                        Type = (AddressType)x.Type
                    }).ToList()
                };

                Add(client);
            }
        }
    }
}