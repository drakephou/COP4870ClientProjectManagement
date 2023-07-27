using COP4870ClientProjectManagement.API.EC;
using Library.ClientProjectManagement.DTO;
using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace COP4870ClientProjectManagement.API.Controllers
{       
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ClientDTO> Get()
        {
            return new ClientEC().Search();
        }

        [HttpGet("/{id}")]
        public ClientDTO? GetId(int id) 
        {
            return new ClientEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public ClientDTO? Delete(int id)
        {
            return new ClientEC().Delete(id);
        }

        [HttpPost("Add")]
        public ClientDTO Add([FromBody] ClientDTO client) 
        {
            return new ClientEC().Add(client);
        }

        [HttpPost("Update")]
        public ClientDTO Update([FromBody] ClientDTO client) 
        {
            return new ClientEC().Update(client);
        }

        [HttpPost("Search")]
        public IEnumerable<ClientDTO> Search([FromBody]QueryMessage query) 
        {
            return new ClientEC().Search(query.Query);
        }
    }
}
