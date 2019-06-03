using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.DatabaseContext;
using System;

namespace Repositorio
{
    public class TransmissoraRepository 
        : Repository<Transmissora>, ITransmissoraRepository
    {
        public TransmissoraRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext
                ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
    }
}
