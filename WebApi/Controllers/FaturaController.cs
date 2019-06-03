using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class FaturaController : ApiController
    {
        public IFaturaRepository FaturaRepository { get; }

        public FaturaController(IFaturaRepository faturaRepository)
        {
            FaturaRepository = faturaRepository
                ?? throw new ArgumentNullException(nameof(faturaRepository));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(FaturaModel model)
        {
            var fatura = Mapper.Map<FaturaModel, Fatura>(model);

            var success = await FaturaRepository.GravarAsync(fatura);

            if (!success)
                return BadRequest();

            return Ok();
        }
    }
}
