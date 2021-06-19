using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Permissions.Test
{
    public class BaseApiTest : IClassFixture<ApiTestFixture>
    {
        protected HttpClient Client { get; } = ApiTestFixture.HttpClient;

        protected async Task<T> GetClient<T>(string requestUri)
        {
            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Deserialize<T>(content);
        }

        protected async Task<TResponse> PostClient<TResponse>(string requestUri, object model)
        {
            var serialized = JsonSerializer.Serialize(model);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            return Deserialize<TResponse>(contentResponse);
        }

        protected async Task<TResponse> PutClient<TResponse>(string requestUri, object model)
        {
            var serialized = JsonSerializer.Serialize(model);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();
            return Deserialize<TResponse>(contentResponse);
        }

        protected static T Deserialize<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
