using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class UserRole :IEntity
    {
        public int Id  { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
