using Decors.Application.Contracts.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Client
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, IDictionary<string, string> headers, string token)
        {

            using (var client = _clientFactory.CreateClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                foreach (var tm in headers)
                {
                    client.DefaultRequestHeaders.Add(tm.Key, tm.Value);
                }
                return await client.GetAsync(url);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content, IDictionary<string, string> headers, string token)
        {
            ;
            using (var client = _clientFactory.CreateClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                foreach (var tm in headers)
                {
                    client.DefaultRequestHeaders.Add(tm.Key, tm.Value);
                }
                return await client.PostAsync(url, content);
            }
        }
        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content, IDictionary<string, string> headers, string token)
        {

            using (var client = _clientFactory.CreateClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                foreach (var tm in headers)
                {
                    client.DefaultRequestHeaders.Add(tm.Key, tm.Value);
                }
                return await client.PutAsync(url, content);
            }
        }
    }
}
