using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private IPetsServices petsServices;
        
        public PetsController(IPetsServices petsServices)
        {
            this.petsServices = petsServices;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Pet>>> GetPets([FromQuery] int childId)
            {
                try
                {
                    IList<Pet> pets = await petsServices.GetAllPetsAsync(childId);
                    return Ok(pets);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<ActionResult<Pet>> GetPet([FromRoute] int id)
            {
                try
                {
                    Pet pet = await petsServices.GetPetAsync(id);
                    return Ok(pet);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Pet>> AddPet([FromBody] Pet pet)
            {
                try
                {
                    Pet added = await petsServices.AddPetAsync(pet);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);  
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            public async Task<ActionResult<Pet>> UpdateChild([FromBody] Pet pet)
            {
                try
                {
                    Pet petUpdated = await petsServices.UpdatePetAsync(pet);
                    return Ok(petUpdated);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Pet>> DeletePet([FromRoute] int id)
            {
                try
                {
                    Pet deletedPet = await petsServices.RemovePetAsync(id);
                    return Ok(deletedPet);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }
    }
}