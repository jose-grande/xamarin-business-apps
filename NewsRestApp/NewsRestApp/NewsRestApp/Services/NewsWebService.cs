using NewsRestApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsRestApp.Services
{
    public class NewsWebService : INewsWebService
    {
        HttpClient client;
        public NewsWebService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
              {
                  if (cert.Issuer == "CN=localhost") return true;
                  return errors == System.Net.Security.SslPolicyErrors.None;
              };
            client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(30);
        }
        public async Task<List<Noticia>> ConsultarV1()
        {
            var uri = "https://localhost:5001/api/noticias";
            var response = await client.GetAsync(uri);
            List<Noticia> result = null;
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Noticia>>(content);
            }
            else
            {   
                Debug.WriteLine(string.Format("Ha ocurrido un error al consultar las noticias: {0}", response.ReasonPhrase));
            }
            return result;
        }
        public List<Noticia> Consultar()
        {
            var uri = "https://127.0.0.1:5001/api/noticias";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            //var response = await client.GetAsync(uri);
            var response = client.SendAsync(request).Result;
            List<Noticia> result = null;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Noticia>>(content);
            }
            else
            {
                Debug.WriteLine(string.Format("Ha ocurrido un error al consultar las noticias: {0}", response.ReasonPhrase));
            }
            return result;
        }
    }
}
