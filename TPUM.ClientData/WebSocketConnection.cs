using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TPUM.ClientData
{
    public abstract class WebSocketConnection : IObservable<bool>
    {
        public virtual Action<string> onMessage { set; protected get; } = x => { };
        public virtual Action onClose { set; protected get; } = () => { };
        public virtual Action onError { set; protected get; } = () => { };

        public async Task SendAsync(string message)
        {
            await SendTask(message);
        }

        public abstract Task DisconnectAsync();

        public abstract Task SendTask(string message);



        public List<IObserver<bool>> observers;

        public IDisposable Subscribe(IObserver<bool> observer)
        {
            observers.Add(observer);
            return null;
        }
    }
}
