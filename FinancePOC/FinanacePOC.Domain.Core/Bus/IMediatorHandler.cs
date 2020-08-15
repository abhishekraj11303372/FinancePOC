using FinanacePOC.Domain.Core.Commands;
using System;
using System.Threading.Tasks;

namespace FinanacePOC.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
