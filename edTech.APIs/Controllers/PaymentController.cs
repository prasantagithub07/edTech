using edTech.APIs.Filters;
using edTech.DomainModels.Entities;
using edTech.DomainModels.Models;
using edTech.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace edTech.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;

        public PaymentController(IPaymentService paymentService, IOrderService orderService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult SavePaymentDetails(PaymentModel model)
        {
            bool IsSignVerified = _paymentService.VerifySignature(model.Signature, model.OrderId, model.PaymentId);
            var paymentDetails = _paymentService.GetPaymentDetails(model.PaymentId);
            if(IsSignVerified && paymentDetails != null)
            {
                PaymentDetails payment = new PaymentDetails();
                payment.CartId = model.CartId;
                payment.Total = model.Total;
                payment.Tax = model.Tax;
                payment.GrandTotal = model.GrandTotal;

                payment.Status = paymentDetails.Attributes["status"];// captured
                payment.Currency = model.Currency;
                payment.Email = model.Email;
                payment.Id = model.PaymentId;
                payment.UserId = model.UserId;

                int status =_paymentService.SavePaymentDetails(payment);
                if(status > 0)
                {
                    _orderService.PlaceOrder(model);
                    ReceiptModel receipt = new ReceiptModel { 
                        PaymentId= payment.Id,
                        Currency = payment.Currency,
                        Email = payment.Email,  
                        GrandTotal = payment.GrandTotal,
                        Status = payment.Status
                    };

                    return Ok(receipt);
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(RazorePayOrderModel razorePayOrder)
        {
            string orderId = _paymentService.CreateOrder(razorePayOrder.GrandTotal * 100, razorePayOrder.Currency, razorePayOrder.Receipt);

            if (string.IsNullOrEmpty(orderId))
                return StatusCode(StatusCodes.Status500InternalServerError);
            else
                return Ok(new { orderId = orderId});
        }
    }
}
