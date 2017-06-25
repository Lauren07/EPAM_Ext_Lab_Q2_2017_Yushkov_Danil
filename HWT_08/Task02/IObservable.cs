using System;

namespace Task02
{
    public interface IObservable
    {
        event EventHandler<PersonEventArgs> PersonsHandler;

        void RegisterObserver(IObserver obs);

        void RemoveObserver(IObserver obs);
    }
}
