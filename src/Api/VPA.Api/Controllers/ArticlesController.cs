using Microsoft.AspNetCore.Mvc;
using VPA.Api.Repositories;
using VPA.Models;

namespace VPA.Api.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly ArticleRepository repository;

        public ArticlesController(ArticleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("")]
        public Task<IEnumerable<Article>> Get(CancellationToken ct = default)
        {
            return repository.GetAsync(ct);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<Article> GetById([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.GetByIdAsync(id, ct);
        }
    }
}
