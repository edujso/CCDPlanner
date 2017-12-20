using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Data.Entities;
using Data.Access;

namespace CCDPlanner.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoryRepository.Get());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get categories.");
            }            
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_categoryRepository.Get(id));
            }
            catch (Exception)
            {
                return BadRequest("Failed to get category.");
            }
        }
        
        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
