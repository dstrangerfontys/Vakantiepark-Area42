using Microsoft.AspNetCore.Mvc;
using VPA.Api.Repositories;
using VPA.Models;

namespace VPA.Api.Controllers
{
    public class StoreLocationsController : ApiController
    {
        private readonly StoreLocationRepository repository;

        public StoreLocationsController(StoreLocationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("")]
        public Task<IEnumerable<StoreLocation>> Get(CancellationToken ct = default)
        {
            return repository.GetAsync(ct);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<StoreLocation> GetById([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.GetByIdAsync(id, ct);
        }

        [HttpPost]
        [Route("")]
        public Task<int> Create([FromBody] StoreLocation storeLocation, CancellationToken ct = default)
        {
            return repository.InsertAsync(storeLocation, ct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public Task<int> Update([FromRoute] int id, [FromBody] StoreLocation storeLocation, CancellationToken ct = default)
        {
            return repository.UpdateAsync(id, storeLocation, ct);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public Task<int> Delete([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.DeleteAsync(id, ct);
        }
    }
}
