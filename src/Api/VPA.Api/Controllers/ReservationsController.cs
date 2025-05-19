using Microsoft.AspNetCore.Mvc;
using VPA.Api.BusinessLogic.Services;
using VPA.Api.Repositories;
using VPA.Api.Services;
using VPA.Models;

namespace VPA.Api.Controllers
{
    public class ReservationsController : ApiController
    {
        private readonly ReservationRepository repository;
        private readonly Reservationservice service;

        public ReservationsController(ReservationRepository repository, Reservationservice service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        public Task<IEnumerable<Reservation>> Get(CancellationToken ct = default)
        {
            return service.GetAsync(ct);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<Reservation> GetById([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.GetByIdAsync(id, ct);
        }

        [HttpPost]
        [Route("")]
        public Task<int> Create([FromBody] Reservation reservation, CancellationToken ct = default)
        {
            return repository.InsertAsync(reservation, ct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public Task<int> Update([FromRoute] int id, [FromBody] Reservation reservation, CancellationToken ct = default)
        {
            return repository.UpdateAsync(id, reservation, ct);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public Task<int> Delete([FromRoute] int id, CancellationToken ct = default)
        {
            return repository.DeleteAsync(id, ct);
        }
    }
}
