using System.Collections.Generic;
using ClientsMVC.Models;

namespace ClientsMVC.Repositories.AddressRepository.Interfaces
{
    public interface IAddressRepository
    {
        void AddRange(List<Address> addresses);
    }
}
