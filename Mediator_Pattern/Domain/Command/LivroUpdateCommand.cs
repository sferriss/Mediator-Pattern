using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_Pattern.Domain.Command
{
    public class LivroUpdateCommand : LivroCreateCommand
    {
        public int Id { get; set; }
    }
}
