using Mediator_Pattern.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_Pattern.EventsHandlers
{
    public class EventsHandler : INotificationHandler<LivroCreateNotification>,
                            INotificationHandler<LivroUpdateNotification>,
                            INotificationHandler<LivroDeleteNotification>,
                            INotificationHandler<ErroNotification>
    {
        public Task Handle(LivroCreateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} " +
                    $"- {notification.Nome} - {notification.Preco}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Erro} \n {notification.PilhaErro}'");
            });
        }

        public Task Handle(LivroUpdateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} " +
                    $"- {notification.Preco} - {notification.IsConcluido}'");
            });
        }

        public Task Handle(LivroDeleteNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} " +
                    $"- {notification.IsConcluido}'");
            });
        }
    }
}
