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
        private string baseUri;
        private string noticiasUri;
        private string categoriasUri;
        public NewsWebService()
        {
            baseUri= "https://localhost:5001";
            noticiasUri = $"{baseUri}/api/noticias";
            categoriasUri = $"{baseUri}/api/categorias";

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
            var response = await client.GetAsync(noticiasUri);
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
            var request = new HttpRequestMessage(HttpMethod.Get, noticiasUri);

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
        public void AgregarNoticia(Noticia noticia)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, noticiasUri);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(noticia);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            //request.Headers.Add("X-API-KEY", "654654654654");
            //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", "token");
            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                //result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Noticia>>(content);
                Debug.WriteLine(content);
            }
            else
            {
                Debug.WriteLine(string.Format("Ha ocurrido un error al consultar las noticias: {0}", response.ReasonPhrase));
            }
        }
        public List<Categoria> ConsultarCategorias()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, categoriasUri);
            var response = client.SendAsync(request).Result;
            List<Categoria> result = null;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Categoria>>(content);
                Debug.WriteLine(content);
            }
            else
            {
                Debug.WriteLine(string.Format("Ha ocurrido un error al consultar las categorias: {0}", response.ReasonPhrase));
            }
            return result;

        }
    }
}
