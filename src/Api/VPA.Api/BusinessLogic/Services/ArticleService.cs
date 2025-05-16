using VPA.Api.Repositories;
using VPA.Models;

namespace VPA.Api.Services
{
    public class ArticleService : IService
    {
        private readonly ArticleRepository repository;

        public ArticleService(ArticleRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Article>> GetAsync(CancellationToken ct = default)
        {
            // Hier kunnen we eventueel logica toevoegen

            return repository.GetAsync(ct);
        }
    }
}
