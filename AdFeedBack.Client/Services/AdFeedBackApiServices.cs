using AdFeedBack.Client.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;


namespace AdFeedBack.Client.Services
{
    public class AdFeedBackApiServices : IAdFeedBackApiService
    {
        public HttpClient Client { get; set; }

        public AdFeedBackApiServices(HttpClient client)
        {
            Client = client;
        }

        //private string GetToken()
        //{
        //    return _contextAccessor.HttpContext.User.FindFirstValue("APIAccessToken");
        //}

        public async Task<IActionResult> GetAsync(string uri)
        {
            HttpResponseMessage httpResponse = await Client.GetAsync(uri);
            using var content = await httpResponse.Content.ReadAsStreamAsync();
            string response = null;
            using (var reader = new StreamReader(content, Encoding.UTF8))
            {
                response = reader.ReadToEnd();
            }
            return new ObjectResult(response) { StatusCode = (int)httpResponse.StatusCode };
        }
        public async Task<IActionResult> PostAsync(string uri, Object obj)
        {
            HttpResponseMessage httpResponse = await Client.PostAsJsonAsync(uri, obj);
            using var content = await httpResponse.Content.ReadAsStreamAsync();
            string response = null;
            using (var reader = new StreamReader(content, Encoding.UTF8))
            {
                response = reader.ReadToEnd();
            }
            return new ObjectResult(response) { StatusCode = (int)httpResponse.StatusCode };
        }
    }
}
