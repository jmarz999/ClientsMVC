using System.Collections.Generic;
using ClientsMVC.Models;
using ClientsMVC.Models.EntityFramework;
using ClientsMVC.Repositories.AddressRepository.Interfaces;

namespace ClientsMVC.Repositories.AdressRepository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext context;

        public AddressRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddRange(List<Address> addresses)
        {
            context.Addressess.AddRange(addresses);
            context.SaveChanges();
        }
    }
}
