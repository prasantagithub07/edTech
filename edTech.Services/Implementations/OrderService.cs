using edTech.DAL.Interfaces;
using edTech.DomainModels.Entities;
using edTech.DomainModels.Models;
using edTech.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;   
        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public OrderModel GetOrderDetails(string orderId)
        {
            var model = _orderRepo.GetOrderDetails(orderId);
            if(model != null && model.Items.Count > 0)
            {
                decimal subTotal = 0;
                foreach(var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;
                }
                model.Total = subTotal;
                //5% tax
                model.Tax = Math.Round(model.Total * 5) / 100;
                model.GrandTotal = model.Total + model.Tax;
            }
            return model;
        }

        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return _orderRepo.GetUserOrders(userId);
        }

        public int PlaceOrder(PaymentModel model)
        {
            Order order = new Order
            {
                PaymentId = model.PaymentId,
                UserId = model.UserId,
                CreatedDate = DateTime.Now,
                Id = model.OrderId
            };

            foreach(var item in model.Items)
            {
                var orderIdtem = new OrderItem {ItemId= item.Id, OrderId=model.OrderId, Quantity=item.Quantity, UnitPrice=item.UnitPrice, Total=item.Total };
                order.Items.Add(orderIdtem);    
            }

            _orderRepo.Add(order);
            return _orderRepo.SaveChanges();
        }
    }
}
