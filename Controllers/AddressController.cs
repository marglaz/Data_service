using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dadata_service.Models;


namespace Dadata_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IDadataService _dadataService;

        public AddressController(IDadataService dadataService)
        {
            _dadataService = dadataService;
        }

        [HttpGet("clean")]
        public async Task<ActionResult<AddressResponse>> Clean(string rawAddress)
        {
            if (string.IsNullOrEmpty(rawAddress))
            {
                return BadRequest("Сырой адрес не может быть пустым.");
            }

            var cleanAddress = await _dadataService.CleanAddressAsync(rawAddress);
            if (cleanAddress is null)
            {
                return NotFound("Адрес не найден.");
            }

            return Ok(cleanAddress);
        }
    }
}
