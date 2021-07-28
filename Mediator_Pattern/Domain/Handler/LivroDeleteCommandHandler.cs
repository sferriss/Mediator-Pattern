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
    public class LivroDeleteCommandHandler : IRequestHandler<LivroDeleteCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly ILivroRepository<Livro> _repository;

        public LivroDeleteCommandHandler(IMediator mediator, ILivroRepository<Livro> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(LivroDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new LivroDeleteNotification
                { Id = request.Id, IsConcluido = true });

                return await Task.FromResult("Livro excluido com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new LivroDeleteNotification
                {
                    Id = request.Id,
                    IsConcluido = false
                });

                await _mediator.Publish(new ErroNotification
                {
                    Erro = ex.Message,
                    PilhaErro = ex.StackTrace
                });

                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
