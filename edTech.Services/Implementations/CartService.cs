using edTech.DAL.Interfaces;
using edTech.DomainModels.Entities;
using edTech.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;
        public CartService(ICartRepository repo)
        {
            _repo = repo;
        }
        public bool SaveCart(Cart cart)
        {
            return _repo.SaveCart(cart);
        }
    }
}
