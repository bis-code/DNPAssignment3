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
    public class ChildrenController : ControllerBase
    {
        private IChildServices childServices;
        
        public ChildrenController(IChildServices childServices)
        {
            this.childServices = childServices;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetChildren([FromQuery] int familyId)
            {
                try
                {
                    IList<Child> children = await childServices.GetAllChildrenAsync(familyId);
                    return Ok(children);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet]
            [Route("{id:int}")]
            public async Task<ActionResult<Adult>> GetChild([FromRoute] int id)
            {
                try
                {
                    Child child = await childServices.GetChildAsync(id);
                    return Ok(child);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Adult>> AddChild([FromBody] Child child)
            {
                try
                {
                    Child added = await childServices.AddChildAsync(child);
                    return Created($"/{added.Id}", added);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);  
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            public async Task<ActionResult<Adult>> UpdateChild([FromBody] Child child)
            {
                try
                {
                    Child childUpdated = await childServices.UpdateChildAsync(child);
                    return Ok(childUpdated);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Family>> DeleteChild([FromRoute] int id)
            {
                try
                {
                    Child deletedChild = await childServices.RemoveChildAsync(id);
                    return Ok(deletedChild);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, e.Message);
                }
            }
    }
}