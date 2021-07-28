using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_Pattern.Domain.Command
{
    public class LivroCreateCommand : IRequest<string>
    {

        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
    }
}
