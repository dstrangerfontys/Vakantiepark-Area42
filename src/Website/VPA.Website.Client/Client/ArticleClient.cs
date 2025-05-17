using VPA.Models;

namespace VPA.Website.Client
{
    public class ArticleClient : ApiClient
    {
        private const string EndPoint = "articles";

        public ArticleClient(IHttpClientFactory httpClientFactory, ApiOptions options)
            : base(httpClientFactory, options)
        {
            //
        }

        public Task<List<Article>> GetAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<List<Article>>($"{EndPoint}", cancellationToken);
        }

        public Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return GetAsync<Article>($"{EndPoint}/{id}", cancellationToken);
        }

        public Task CreateAsync(Article article, CancellationToken cancellationToken = default)
        {
            return PostAsync($"{EndPoint}", article, cancellationToken);
        }

        public Task UpdateAsync(Article article, CancellationToken cancellationToken = default)
        {
            return PutAsync($"{EndPoint}/{article.Id}", article, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync($"{EndPoint}/{id}", cancellationToken);
        }
    }
}
