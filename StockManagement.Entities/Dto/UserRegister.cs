using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Dto
{
    /// <summary>
    /// Register DTO
    /// </summary>
    public class UserRegister: IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
