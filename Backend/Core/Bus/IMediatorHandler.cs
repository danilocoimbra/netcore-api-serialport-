using System.Threading.Tasks;
using Backend.Core.Commands;
using Backend.Core.Events;

namespace Backend.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
