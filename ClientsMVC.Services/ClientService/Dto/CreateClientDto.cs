using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientsMVC.Services.ClientService.Dto
{
    public class CreateClientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public List<AddressDto> Addressess { get; set; }
    }
}
