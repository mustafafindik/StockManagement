using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.Core.Entities.Concrete;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class UserRepository: EntityRepository<User, ApplicationDbContext>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Role> GetRoles(User user)
        {
            var result = _context.UserRoles.Include(q => q.Role).Where(q => q.UserId == user.Id)
                .Select(q => new Role()
                {
                    Id = q.Role.Id,
                    Name = q.Role.Name,
                    Description = q.Role.Description

                }).ToList();
            return result;
        }
    }
}
