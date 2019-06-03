using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Base
{
    public interface IRepositoryBase<T> : IRepository where T : EntidadeBase
    {
        Task<bool> GravarAsync(T objeto);
        Task<bool> Atualizar(T objeto);
        List<T> Obter(Expression<Func<T, bool>> condicao);
        List<T> ObterTodos();
        T ObterPorId(int Id);        
    }
}
