using Microsoft.AspNetCore.Mvc;
using VPA.Api.BusinessLogic.Services;
using VPA.Api.Repositories;
using VPA.Api.Services;
using VPA.Models;

namespace VPA.Api.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly ArticleRepository repository;
        private readonly Articleservice service;

        public ArticlesController(ArticleRepository repository, Articleservice service)
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

        [HttpPost]
        [Route("")]
        public Task<int> Create([FromBody] Article article, CancellationToken ct = default)
        {
            return repository.InsertAsync(article, ct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public Task<int> Update([FromRoute] int id, [FromBody] Article article, CancellationToken ct = default)
        {
            return repository.UpdateAsync(id, article, ct);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public Task<int> Delete([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.DeleteAsync(id, ct);
        }
    }
}
