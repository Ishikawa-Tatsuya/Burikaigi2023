using System.Net.Http.Json;

namespace Burikaigi.Client.Services
{
    public class HttpService
    {
        readonly HttpClient _http;

        public HttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<TValue?> GetFromJsonAsync<TValue>(string url) where TValue : class
        {
            try
            {
                var httpResponse = await _http.GetAsync(url);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent) return null;
                if (httpResponse.Content.Headers?.ContentType?.MediaType == "text/plain")
                {
                    await CheckResponse(httpResponse);
                    return null;
                }
                return await httpResponse.Content.ReadFromJsonAsync<TValue>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> PostAsJsonAsync<TValue>(string url, TValue data)
        {
            var response = await _http.PostAsJsonAsync(url, data);
            return await CheckResponse(response);
        }

        async Task<bool> CheckResponse(HttpResponseMessage? response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));
            if (response.Content.Headers?.ContentType?.MediaType == "text/plain")
            {
                var error = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }
    }
}
