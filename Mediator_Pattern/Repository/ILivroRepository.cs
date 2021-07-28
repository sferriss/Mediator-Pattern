using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_Pattern.Repository
{
    public interface ILivroRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T livro);
        Task Edit(T livro);
        Task Delete(int id);
    }
}
