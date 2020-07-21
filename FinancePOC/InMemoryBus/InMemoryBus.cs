using FinanacePOC.Domain.Core.Bus;
using FinanacePOC.Domain.Core.Commands;
using MediatR;
using System;
using System.Threading.Tasks;

namespace FinancePOC.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
