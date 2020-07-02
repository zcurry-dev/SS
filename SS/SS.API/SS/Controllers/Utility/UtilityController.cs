using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Interfaces;
using SS.Business.Models.Utility;

namespace SS.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilityController : ControllerBase
    {
        private readonly IUtilityRepository _utility;

        public UtilityController(IUtilityRepository utility) { _utility = utility; }

        [HttpGet]
        [Route("ListCountries")]
        public async Task<IActionResult> ListCountries()
        {
            var countries = await _utility.GetCountries();
            return Ok(countries);
        }

        [HttpGet]
        [Route("ListUSStates")]
        public async Task<IActionResult> ListUSStates()
        {
            var states = await _utility.GetUsStates();
            return Ok(states);
        }

        [HttpGet]
        [Route("ListUSStateCities/{usStateId}")]
        public async Task<IActionResult> ListUSStateCities(int usStateId)
        {
            var cities = await _utility.GetUsCities(usStateId);
            return Ok(cities);
        }

        [HttpGet]
        [Route("ListZipCodes/{usCityId}")]
        public async Task<IActionResult> ListZipCodes(int usCityId)
        {
            var zipCodes = await _utility.GetZipCodes(usCityId);
            return Ok(zipCodes);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity(CityToCreateDto cityToCreateDto)
        {
            var city = await _utility.CreateCity(cityToCreateDto);

            if (city.Id > 0)
            {
                return CreatedAtRoute(
                    city.Id,
                    city);
            }

            if (city.Id == -1)
            {
                return BadRequest("City already exists for this State");
            }

            return BadRequest("Could not create city");
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("CreateZipCode")]
        public async Task<IActionResult> CreateZipcode(ZipCodeToCreateDto zipCodeToCreateDto)
        {
            var zipCode = await _utility.CreateZipCode(zipCodeToCreateDto);

            if (zipCode.Id > 0)
            {
                return CreatedAtRoute(
                    zipCode.Id,
                    zipCode);
            }

            if (zipCode.Id == -1)
            {
                return BadRequest("ZipCode already exists for this City");
            }

            return BadRequest("Could not create zipCode");
        }



    }
}