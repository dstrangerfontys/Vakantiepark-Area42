using VPA.Models;

namespace VPA.Website.Client
{
    public class StoreLocationClient : ApiClient
    {
        private const string EndPoint = "storelocations";

        public StoreLocationClient(IHttpClientFactory httpClientFactory, ApiOptions options)
            : base(httpClientFactory, options)
        {
            //
        }

        public Task<List<StoreLocation>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync<List<StoreLocation>>($"{EndPoint}", ct);
        }

        public Task<StoreLocation> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<StoreLocation>($"{EndPoint}/{id}", ct);
        }

        public Task CreateAsync(StoreLocation storeLocation, CancellationToken ct = default)
        {
            return PostAsync($"{EndPoint}", storeLocation, ct);
        }

        public Task UpdateAsync(StoreLocation storeLocation, CancellationToken ct = default)
        {
            return PutAsync($"{EndPoint}/{storeLocation.Id}", storeLocation, ct);
        }

        public Task DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync($"{EndPoint}/{id}", ct);
        }
    }
}
