using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Serialization;

namespace WebHook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private static readonly List<OrderNotification> _orders = new List<OrderNotification>();


        [HttpPost]
        public IActionResult Post([FromBody] object data, [FromHeader(Name = "Content-Type")] string contentType)
        {
            OrderNotification notification = null;

            if (contentType == "application/json")
            {
                notification = JsonSerializer.Deserialize<OrderNotification>(data.ToString());
            }
            else if (contentType == "application/xml")
            {
                var serializer = new XmlSerializer(typeof(OrderNotification));
                using (var reader = new StringReader(data.ToString()))
                {
                    notification = (OrderNotification)serializer.Deserialize(reader);
                }
            }

            if (notification == null)
            {
                return BadRequest();
            }

            // Speichern der Bestellung in der in-memory Liste
            _orders.Add(notification);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Rückgabe aller gespeicherten Bestellungen
            return Ok(JsonSerializer.Serialize(_orders));
        }
    }

    public class OrderNotification
    {
        public string OrderId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
