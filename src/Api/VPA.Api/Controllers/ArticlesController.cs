using Microsoft.AspNetCore.Mvc;
using VPA.Api.Repositories;
using VPA.Api.Services;
using VPA.Models;

namespace VPA.Api.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly ArticleRepository repository;
        private readonly ArticleService service;

        public ArticlesController(ArticleRepository repository, ArticleService service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        public Task<IEnumerable<Article>> Get(CancellationToken ct = default)
        {
            return service.GetAsync(ct);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<Article> GetById([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.GetByIdAsync(id, ct);
        }
    }
}
