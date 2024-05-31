using Akshay.ProjectDemo.Entities;
using Akshay.ProjectDemo.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akshay.ProjectDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IGenericRepo<Country> _repository;

        public CountryController(IGenericRepo<Country> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetAll();
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
