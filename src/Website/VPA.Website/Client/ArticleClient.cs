using VPA.Website.Models;

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
    }
}
