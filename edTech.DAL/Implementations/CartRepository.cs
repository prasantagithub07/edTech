using edTech.DAL.Interfaces;
using edTech.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.DAL.Implementations
{
    public class CartRepository: Repository<Cart>, ICartRepository
    {
        public CartRepository(DbContext dbContext) : base(dbContext)
        {
        }

        private AppDbContext dbContext
        {
            get { return _dbContext as AppDbContext; }
        }

        public bool SaveCart(Cart cart)
        {
            dbContext.Carts.Add(cart);
            dbContext.SaveChanges();
            return true;

        }
    }
}
