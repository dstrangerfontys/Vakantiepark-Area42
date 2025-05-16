using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace VPA.Website.Client
{
    public class ApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiOptions options;

        private HttpClient _httpClient;

        public ApiClient(IHttpClientFactory httpClientFactory, ApiOptions options)
        {
            this.httpClientFactory = httpClientFactory;
            this.options = options;
        }

        #region Properties

        protected HttpClient HttpClient
            => _httpClient ??= CreateHttpClient();

        private JsonSerializerOptions JsonSerializerOptions
            => options.JsonSerializerOptions;

        #endregion

        protected async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken ct = default)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(requestUri, ct);
            ValidateHttpResponse(response);
            return response;
        }

        protected async Task<TResult> GetAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(requestUri, ct);
            ValidateHttpResponse(response);
            return await GetValueAsync<TResult>(response, ct);
        }

        protected async Task PutAsync<TModel>(string requestUri, TModel model, CancellationToken ct = default)
        {
            using HttpResponseMessage response = await HttpClient.PutAsJsonAsync(requestUri, model, JsonSerializerOptions, ct);
            ValidateHttpResponse(response);
        }

        protected async Task<TResult> PutAsync<TModel, TResult>(string requestUri, TModel model, CancellationToken ct = default)
        {
            using HttpResponseMessage response = await HttpClient.PutAsJsonAsync(requestUri, model, JsonSerializerOptions, ct);
            ValidateHttpResponse(response);
            return await GetValueAsync<TResult>(response, ct);
        }

        protected async Task PostAsync(string requestUri, CancellationToken ct = default)
        {
            using HttpResponseMessage response = await HttpClient.PostAsync(requestUri, content: null, ct);
            ValidateHttpResponse(response);
        }

        protected async Task PostAsync<TModel>(string requestUri, TModel model, CancellationToken ct = default)
        {
            using HttpResponseMessage response = await HttpClient.PostAsJsonAsync(requestUri, model, JsonSerializerOptions, ct);
            ValidateHttpResponse(response);
        }

        protected async Task<TResult> PostAsync<TModel, TResult>(string requestUri, TModel model, CancellationToken ct = default)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(requestUri, model, JsonSerializerOptions, ct);
            ValidateHttpResponse(response);
            return await GetValueAsync<TResult>(response, ct);
        }

        protected async Task DeleteAsync(string requestUri, CancellationToken ct = default)
        {
            using HttpResponseMessage response = await HttpClient.DeleteAsync(requestUri, ct);
            ValidateHttpResponse(response);
        }

        protected virtual Task<TValue> GetValueAsync<TValue>(HttpResponseMessage response, CancellationToken ct = default)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return Task.FromResult<TValue>(default);
            }

            return response.Content.ReadFromJsonAsync<TValue>(JsonSerializerOptions, ct);
        }

        protected virtual HttpClient CreateHttpClient()
        {
            return httpClientFactory.CreateClient(options.HttpClientName);
        }

        protected virtual void ValidateHttpResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
        }
    }
}
