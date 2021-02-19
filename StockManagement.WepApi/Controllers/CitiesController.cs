using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.Core.Extensions;
using StockManagement.Entities.Concrete;

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
            var userıd = User.ClaimId();

            var result = _cityService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);

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
                return Ok(result);
            }

            return BadRequest(result);

        }


        /// <summary>
        /// Metoda gelen nesne örnegini veritabanına ekler.
        /// </summary>
        /// <returns> Dönüş olarak IResult Sınıfından döner.</returns>

        [HttpPost("add")]

        public IActionResult Add(City city)
        {

            var result = _cityService.Add(city);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Metoda gelen nesne örnegini veritabanında günceller.
        /// </summary>
        /// <returns> Dönüş olarak IResult Sınıfından döner.</returns>
        [HttpPost("update")]
        public IActionResult Update(City city)
        {
            var result = _cityService.Update(city);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }


        /// <summary>
        /// Metoda gelen nesne örnegini veritabanından siler.
        /// </summary>
        /// <returns> Dönüş olarak IResult Sınıfından döner.</returns>

        [HttpPost("delete")]
        public IActionResult Delete(City city)
        {
            var result = _cityService.Delete(city);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
