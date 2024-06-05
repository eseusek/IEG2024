using FTPProductService.Models;
using System.Net;

namespace FTPProductService.Services
{
    public class FtpProductService
    {
        private readonly string ftpUrl = "ftp://some-ftp-server.com/products.txt";
        private readonly string ftpUser = "ftp-username";
        private readonly string ftpPassword = "ftp-password";

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUser, ftpPassword);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    products.Add(new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Price = decimal.Parse(parts[2])
                    });
                }
            }

            return products;
        }
    }
}
