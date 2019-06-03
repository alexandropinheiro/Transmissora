using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("Transmissora")]
    public class TransmissoraController : ApiController
    {
        public ITransmissoraRepository TransmissoraRepository { get; }        

        public TransmissoraController(ITransmissoraRepository transmissoraRepository)
        {
            TransmissoraRepository = transmissoraRepository
                ?? throw new ArgumentNullException(nameof(transmissoraRepository));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] TransmissoraModel model)
        {
            var transmissora = Mapper.Map<TransmissoraModel, Transmissora>(model);

            var success = await TransmissoraRepository.GravarAsync(transmissora);

            if (!success)
                return BadRequest();

            return Ok();
        }
    }
}
