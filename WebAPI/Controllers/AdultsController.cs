using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using Models;
using WebAPI.Data;
using WebClient.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultServices _adultServices;
        
        public AdultsController(IAdultServices adultServices)
        {
            _adultServices = adultServices;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] int familyId)
            {
                try
                {
                    IList<Adult> adults = await _adultServices.GetAllAdultsAsync(familyId);
                    return Ok(adults);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<ActionResult<Adult>> GetAdult([FromRoute] int id)
            {
                try
                {
                    Adult adult = await _adultServices.GetAdultAsync(id);
                    return Ok(adult);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
            {
                try
                {
                    Adult added = await _adultServices.AddAdultAsync(adult);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);  
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
            {
                try
                {
                    Adult adultUpdated = await _adultServices.UpdateAdultAsync(adult);
                    return Ok(adultUpdated);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> DeteleAdult([FromRoute] int id)
            {
                try
                {
                    Adult deletedAdult = await _adultServices.RemoveAdultAsync(id);
                    return Ok(deletedAdult);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }
    }
}