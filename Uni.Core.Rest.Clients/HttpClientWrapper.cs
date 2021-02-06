using System.Net.Http;
using System.Threading.Tasks;

namespace Uni.Core.Rest.Clients
{
    public class HttpClientWrapper: IHttpClientWrapper
    {
        private readonly HttpClient _internalClient;

        public HttpClientWrapper()
        {
            _internalClient = new HttpClient();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _internalClient.GetAsync(url);
        }

        public Task<HttpResponseMessage> PostAsync(string url, StringContent content)
        {
            return _internalClient.PostAsync(url, content);
        }

        public Task<HttpResponseMessage> PutAsync(string url, StringContent content)
        {
            return _internalClient.PutAsync(url, content);
        }

        public Task<HttpResponseMessage> PatchAsync(string url, StringContent content)
        {
            return _internalClient.PatchAsync(url, content);
        }
    }
}
