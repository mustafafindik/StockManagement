﻿using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class User:IEntity
    {
        public User()
        {

        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
