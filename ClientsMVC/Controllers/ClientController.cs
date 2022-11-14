using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ClientsMVC.Services.ClientService.Dto;
using ClientsMVC.Services.ClientService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientsMVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var clients = clientService.GetAll();

                return View(clients);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var client = new CreateClientDto();

            return View(client);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClientDto client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientService.Add(client);

                    return RedirectToAction(nameof(Index));
                }

                return View(client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportClients(IFormFile clientXml)
        {
            try
            {
                string fileContents;
                using (var stream = clientXml.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    fileContents = await reader.ReadToEndAsync();
                }

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Clients));

                using (TextReader reader = new StringReader(fileContents))
                {
                    Clients clients = (Clients)xmlSerializer.Deserialize(reader);
                    clientService.ImportClients(clients.Client.ToList());
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
