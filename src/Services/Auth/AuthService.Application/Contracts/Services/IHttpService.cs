using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content, IDictionary<string, string> headers, string token);
        Task<HttpResponseMessage> GetAsync(string url, IDictionary<string, string> headers, string token);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content, IDictionary<string, string> headers, string token);
    }
}
