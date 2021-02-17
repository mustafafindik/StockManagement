﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Business.Abstract;
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
        /// Bu Tüm Listeyi döner get İsteği Herhangi parametre almadığı zaman Tüm Listeyi Döner
        /// </summary>
        /// <returns> İçinde Data Listesi Olan Bir IDataResult Döner</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _cityService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        /// <summary>
        /// Bu Tüm Listeyi döner get   parametre aldığı için id ye ait sonuçu döner
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
        /// Gerekli Sınıfın nesne örnegini alıp, Veritabanına Ekler
        /// </summary>
        /// <returns> Mesaj olarak IResult Sınıfından döner.</returns>

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
        /// Gerekli Sınıfın nesne örnegini alıp, Veritabanında Günceller
        /// </summary>
        /// <returns> Mesaj olarak IResult Sınıfından döner.</returns>
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
        /// Gerekli Sınıfın nesne örnegini alıp, Veritabanında Siler
        /// </summary>
        /// <returns> Mesaj olarak IResult Sınıfından döner.</returns>

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