using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebHookSubscriber
{
    public class OrderNotification
    {
        public string OrderId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        private static HashSet<string> processedOrderIds = new HashSet<string>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Subscriber Beispiel (alle 10 Sekunden)");

            string url = "https://localhost:7099/api/webhook";

            using (HttpClient client = new HttpClient())
            {
                // GitHub API benötigt einen User-Agent Header
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                var counter = 0;
                while (true)
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<OrderNotification> orders = JsonSerializer.Deserialize<List<OrderNotification>>(responseBody);

                        if (orders.Count == 0)
                        {
                            Console.WriteLine("Keine neuen Orders eingegangen!");
                        }
                        else
                        {
                            foreach (var order in orders)
                                {
                                    if (!processedOrderIds.Contains(order.OrderId))
                                    {
                                        counter++;
                                        Console.WriteLine("Neue Order eingegangen:");
                                        Console.WriteLine($"OrderId: {order.OrderId}, Product: {order.Product}, Quantity: {order.Quantity}");
                                        processedOrderIds.Add(order.OrderId);
                                    }
                                }
                            if (counter == 0)
                            {
                                Console.WriteLine("Keine neuen Orders eingegangen!");
                            }
                            counter = 0;
                        }
                        
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"[{DateTime.Now}] Request error: {e.Message}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"[{DateTime.Now}] Fehler: {e.Message}");
                    }

                    // 30 Sekunden warten
                    await Task.Delay(10000);
                }
            }
        }
    }
}