using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_Pattern.Domain.Command
{
    public class LivroDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
