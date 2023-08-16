using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skeleton.Models;
using skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        private readonly IClientRepository _client;
        public ClientController(IClientRepository client)
        {
            _client = client ??
                throw new ArgumentNullException(nameof(client));
        }
        [HttpGet]
        [Route("GetClient")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetClients());
        }
        [HttpGet]
        [Route("GetClientByID/{Id}")]
        public async Task<IActionResult> GetClientByID(int Id)
        {
            return Ok(await _client.GetClientByID(Id));
        }
        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> Post(Client client)
        {
        
            var result = await _client.InsertClient(client);
            if (result.ClientID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateClient")]
        public async Task<IActionResult> Put(Client client)
        {
            await _client.UpdateClient(client);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteClient")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _client.DeleteClient(id);
            return new JsonResult("Deleted Successfully");
        }

    }
}
