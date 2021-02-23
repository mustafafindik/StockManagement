using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.Entities.Concrete;
using StockManagement.Entities.Dto;

namespace StockManagement.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// Get İsteği Herhangi parametre almadığı zaman Tüm Listeyi Döner
        /// </summary>
        /// <returns> İçinde Data Listesi Olan Bir IDataResult Döner</returns>
        [HttpGet]
        public IActionResult Get()
        {


            var result = _cityService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(new { Message = result.Message });

        }

        /// <summary>
        /// Get Medodu parametre aldığı için id ye ait sonuçu döner
        /// </summary>
        /// <returns> İçinde Data Bir IDataResult Döner</returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _cityService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(new { Message = result.Message });

        }


        /// <summary>
        /// Metoda gelen nesne örnegini veritabanına ekler.
        /// </summary>
        /// <returns> Dönüş olarak IResult Sınıfından döner.</returns>

        [HttpPost("add")]

        public IActionResult Add(CityDto cityDto)
        {

            var result = _cityService.Add(cityDto);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }

            return BadRequest(new { Message = result.Message });
        }

        /// <summary>
        /// Metoda gelen nesne örnegini veritabanında günceller.
        /// </summary>
        /// <returns> Dönüş olarak IResult Sınıfından döner.</returns>
        [HttpPost("update")]
        public IActionResult Update([FromBody] CityDto cityDto)
        {


            var result = _cityService.Update(cityDto);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }

            return BadRequest(new { Message = result.Message });
        }


        /// <summary>
        /// Metoda gelen nesne örnegini veritabanından siler.
        /// </summary>
        /// <returns> Dönüş olarak IResult Sınıfından döner.</returns>

        [HttpPost("delete")]
        public IActionResult Delete(CityDto cityDto)
        {
            var result = _cityService.Delete(cityDto);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }

            return BadRequest(new { Message = result.Message });
        }
    }
}
