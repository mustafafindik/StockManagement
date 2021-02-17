using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Business.Abstract;
using StockManagement.Entities.Dto;

namespace StockManagement.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>
        /// Login Metodu 
        /// </summary>
        /// <param name="loginDto">Kullanıcıdan gelen login bilgileri</param>
        /// <returns>Sonunda Staus Kodu ve Token,Mesaj Döner</returns>

        [HttpPost("login")]
        public ActionResult Login(UserLogin loginDto)
        {
            var userToLogin = _authService.Login(loginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        /// <summary>
        /// Register Metodu
        /// </summary>
        /// <param name="registerDto">Kullanıcıdan gelen Register bilgileri</param>
        /// <returns>Sonunda Staus Kodu ve Token,Mesaj Döner</returns>
        [HttpPost("register")]
        public ActionResult Register(UserRegister registerDto)
        {
            var userExists = _authService.UserExists(registerDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(registerDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }


}
