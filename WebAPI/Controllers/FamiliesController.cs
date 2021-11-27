using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using Models;
using WebClient.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private IFamilyService familyService;

            public FamiliesController(IFamilyService familyService)
            {
                this.familyService = familyService;
            }

            [HttpGet]
            public async Task<ActionResult<IList<Family>>> GetFamilies([FromQuery] int? id)
            {
                try
                {
                    IList<Family> families = await familyService.GetAllFamiliesAsync();

                    if (id != null) //filter by id
                    {
                        families = families.Where(adult => adult.Id == id).ToList();
                    }

                    return Ok(families);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> GetFamily([FromRoute] int id)
            {
                try
                {
                    Family family = await familyService.GetFamilyAsync(id);
                    return Ok(family);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
            {
                try
                {
                    Family added = await familyService.AddFamilyAsync(family);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> UpdateFamily([FromBody] Family family)
            {
                try
                {
                    await familyService.UpdateAsync(family);
                    return Ok(family);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> DeleteFamily([FromRoute] int id)
            {
                try
                {
                    Family deletedFamily = await familyService.RemoveFamilyAsync(id);
                    return Ok(deletedFamily);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
    }
}