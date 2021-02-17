using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Dto
{
    /// <summary>
    /// Login DTO
    /// </summary>
    public class UserLogin:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
