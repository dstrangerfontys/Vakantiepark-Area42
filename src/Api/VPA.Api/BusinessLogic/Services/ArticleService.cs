using VPA.Api.Repositories;
using VPA.Models;

namespace VPA.Api.Services
{
    public class Articleservice : IService
    {
        private readonly ArticleRepository repository;

        public Articleservice(ArticleRepository repository)
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
