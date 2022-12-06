using edTech.DomainModels.Entities;
using edTech.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Interfaces
{
    public interface IOrderService
    {
        OrderModel GetOrderDetails(string orderId);
        IEnumerable<Order> GetUserOrders(int userId);
        int PlaceOrder(PaymentModel model);
    }
}
