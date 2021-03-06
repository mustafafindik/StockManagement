﻿using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class SubCategoryRepository : EntityRepository<SubCategory, ApplicationDbContext>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
