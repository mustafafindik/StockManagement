using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Concrete;
using StockManagement.Core.Utilities.IoC;
using StockManagement.Entities.Concrete;

namespace StockManagement.Business.Helpers
{
    public class SetDateAndUserService : ISetDateAndUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SetDateAndUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = ServiceHelper.ServiceProvider.GetService<IHttpContextAccessor>();
        }


        public  IEntity ForAdd(BaseEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            return (IEntity)entity;
        }

        public IEntity ForUpdate(BaseEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            return (IEntity)entity;
        }
    }
}
