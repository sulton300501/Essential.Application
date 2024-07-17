using Essential.Application.Abstraction.Services;
using Essential.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Essential.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EssentialController : ControllerBase
    {

        private readonly IEssentialService _essential;

        public EssentialController(IEssentialService essential)
        {
            _essential = essential;
        }



        [HttpPost]
        public async Task<IActionResult> Create(EssentialModelDTO essentialModelDTO)
        {
            var result = await _essential.Create(essentialModelDTO);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var result = await _essential.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _essential.GetById(id);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id , EssentialModelDTO essentialModel)
        {
            var result = await _essential.UpdateAsync(id, essentialModel);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _essential.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEngWord(string name)
        {
            var result = await _essential.GetByEngWord(name);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByBookNameAndBookNumberAndUnitNumber(string bookName, int bookNumber, int unitNumber)
        {
            var result = await _essential.GetByBookNameAndBookNumberAndUnitNumber(bookName, bookNumber, unitNumber);
            return Ok(result);
        }





    }
}
