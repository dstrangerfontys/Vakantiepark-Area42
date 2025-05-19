using VPA.Models;

namespace VPA.Website.Client
{
    public class ArticleClient : ApiClient
    {
        private const string EndPoint = "Articles";

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

        public Task CreateAsync(Article Article, CancellationToken cancellationToken = default)
        {
            return PostAsync($"{EndPoint}", Article, cancellationToken);
        }

        public Task UpdateAsync(Article Article, CancellationToken cancellationToken = default)
        {
            return PutAsync($"{EndPoint}/{Article.Id}", Article, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return DeleteAsync($"{EndPoint}/{id}", cancellationToken);
        }
    }
}
