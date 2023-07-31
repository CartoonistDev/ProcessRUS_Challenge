using FruitsAPI.Models.Dto;
using FruitsAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FruitsAPI.Controllers
{
    [Route("api/access")]
    [ApiController]
    [Authorize]
    public class AccessController : Controller
    {
        private readonly IFruitService _fruitService;
        private ResponseDto _response;

        public AccessController(IFruitService fruitService)
        {
            _fruitService= fruitService;
            _response= new ResponseDto();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN, BACKOFFICE")]
        public async Task<IActionResult> GetAllFruits()
        {
            try
            {
                var fruitList = await _fruitService.GetAllFruits();
                _response = fruitList;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = "Error while trying to return list of fruits.";
                return BadRequest(_response);
            }
        }

    }
}
