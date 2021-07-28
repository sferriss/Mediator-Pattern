using Mediator_Pattern.Domain.Command;
using Mediator_Pattern.Domain.Entity;
using Mediator_Pattern.Notifications;
using Mediator_Pattern.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.Domain.Handler
{
    public class LivroCreateCommandHandler : IRequestHandler<LivroCreateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ILivroRepository<Livro> _repository;

        public LivroCreateCommandHandler(IMediator mediator, ILivroRepository<Livro> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(LivroCreateCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro { Nome = request.Nome, Autor = request.Autor, Preco = request.Preco };

            try
            {
                await _repository.Add(livro);
                await _mediator.Publish(new LivroCreateNotification { 
                    Id = livro.Id, 
                    Nome = livro.Nome, 
                    Autor = livro.Autor,
                    Preco = livro.Preco });
                return await Task.FromResult("Livro criado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new LivroCreateNotification { 
                    Id = livro.Id, 
                    Nome = livro.Nome, 
                    Autor = livro.Autor, 
                    Preco = livro.Preco });
                await _mediator.Publish(new ErroNotification { Erro = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
