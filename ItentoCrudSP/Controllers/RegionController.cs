using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItentoCrudSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _regionRepository.SPSelectAsync() );
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string region)
        {
            return Ok(await _regionRepository.SPAddAsync(region));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] string name, int id)
        {
            return Ok(await _regionRepository.SPUpdateAsync(name, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _regionRepository.SPDeleteAsync(id));
        }
    }
}
