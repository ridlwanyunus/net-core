using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public class RestClient(IHttpClientFactory _httpClientFactory)
    {
        public async Task<T?> Get<T>(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();
            return await httpClient.GetFromJsonAsync<T>(url);
        }
    }
}
