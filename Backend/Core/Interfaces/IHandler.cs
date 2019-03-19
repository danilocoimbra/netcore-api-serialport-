using Backend.Core.Events;

namespace Backend.Core.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}