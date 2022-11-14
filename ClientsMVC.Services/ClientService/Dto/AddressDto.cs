using System.ComponentModel.DataAnnotations;
using ClientsMVC.Models;

namespace ClientsMVC.Services.ClientService.Dto
{
    public class AddressDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public AddressType Type { get; set; }
        public int ClientId { get; set; }
    }
}