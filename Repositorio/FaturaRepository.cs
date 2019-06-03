using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.DatabaseContext;
using System;

namespace Repositorio
{
    public class FaturaRepository 
        : Repository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext
                ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
    }
}
