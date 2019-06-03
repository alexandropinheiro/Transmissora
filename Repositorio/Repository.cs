using Dominio.Base;
using Repositorio.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Repository<TEntity> 
        : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext
                ?? throw new ArgumentNullException(nameof(applicationDbContext));
            DbSet = ApplicationDbContext.Set<TEntity>();
        }

        public virtual async Task<bool> GravarAsync(TEntity objeto)
        {
            DbSet.Add(objeto);
            var rowsAffected = await ApplicationDbContext.SaveChangesAsync();
            return rowsAffected == 1;
        }

        public async Task<bool> Atualizar(TEntity objeto)
        {
            DbSet.Add(objeto);
            var rowsAffected = await ApplicationDbContext.SaveChangesAsync();
            return rowsAffected == 1;
        }

        public List<TEntity> Obter(Expression<Func<TEntity, bool>> condicao)
        {
            return ApplicationDbContext.Set<TEntity>()
                .Where(condicao)
                .ToList();
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public TEntity ObterPorId(int Id)
        {
            return ApplicationDbContext.Set<TEntity>().Find(Id);
        }
    }
}
