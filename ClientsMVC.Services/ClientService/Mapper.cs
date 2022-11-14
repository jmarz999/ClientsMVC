using System.Linq;
using ClientsMVC.Models;
using ClientsMVC.Services.ClientService.Dto;

namespace ClientsMVC.Services.ClientService
{
    public static class Mapper
    {
        public static ClientDto EntityToDto(this Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Addressess = client.Adressess.Select(x => x.EntityToDto()).ToList(),
                BirthDate = client.BirthDate,
                Name = client.Name
            };
        }

        public static Client DtoToEntity(this CreateClientDto dto)
        {
            return new Client
            {
                Adressess = dto.Addressess?.Select(x => x.DtoToEntity()).ToList(),
                BirthDate = dto.BirthDate,
                Name = dto.Name
            };
        }

        public static AddressDto EntityToDto(this Address address)
        {
            return new AddressDto
            {
                Name = address.Name,
                Type = address.Type,
                ClientId = address.ClientId
            };
        }

        public static Address DtoToEntity(this AddressDto dto)
        {
            return new Address
            {
                Name = dto.Name,
                Type = dto.Type,
                ClientId = dto.ClientId
            };
        }
    }
}
