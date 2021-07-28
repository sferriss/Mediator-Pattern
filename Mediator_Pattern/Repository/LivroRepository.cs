using Mediator_Pattern.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_Pattern.Repository
{
    public class LivroRepository : ILivroRepository<Livro>
    {
        private static Dictionary<int, Livro> livros = new Dictionary<int, Livro>();

        public async Task Add(Livro livro)
        {
            livro.Id = livros.Count + 1;
            await Task.Run(() => livros.Add(livro.Id, livro));
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => livros.Remove(id));
        }

        public async Task Edit(Livro livro)
        {
            await Task.Run(() =>
            {
                livros.Remove(livro.Id);
                livros.Add(livro.Id, livro);
            });
        }

        public async Task<Livro> Get(int id)
        {
            return await Task.Run(() => livros.GetValueOrDefault(id));
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await Task.Run(() => livros.Values.ToList());
        }
    }
}
