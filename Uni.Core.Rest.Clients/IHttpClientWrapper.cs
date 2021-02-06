using System.Net.Http;
using System.Threading.Tasks;

namespace Uni.Core.Rest.Clients
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, StringContent content);
        Task<HttpResponseMessage> PutAsync(string url, StringContent content);
        Task<HttpResponseMessage> PatchAsync(string url, StringContent content);
    }
}
