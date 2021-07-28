using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_Pattern.Notifications
{
    public class LivroUpdateNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public bool IsConcluido { get; set; }
    }
}
