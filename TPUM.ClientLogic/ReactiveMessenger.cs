using System;
using System.Collections.Generic;
using System.Text;
using TPUM.ClientData;

namespace TPUM.ClientLogic
{
    public class ReactiveMessenger : IObserver<bool>, IObservable<bool>
    {
        public List<IObserver<bool>> observers;

        public ReactiveMessenger(ConnectionService connectionService)
        {
            observers = new List<IObserver<bool>>();
            connectionService.GetClientWebSocket().Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(bool value)
        {
            observers.ForEach(o => o.OnNext(value));
        }

        public IDisposable Subscribe(IObserver<bool> observer)
        {
            observers.Add(observer);
            return null;
        }
    }
}
