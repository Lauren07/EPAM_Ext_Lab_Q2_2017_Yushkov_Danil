using System;

namespace Task02
{
    public class PersonEventArgs : EventArgs
    {
        public DateTime Time { get; }

        public StateGreeting State { get; }

        public PersonEventArgs(DateTime time, StateGreeting stateGreeting)
        {
            this.Time = time;
            this.State = stateGreeting;
        }

        public PersonEventArgs(StateGreeting stateGreeting)
        {
            this.State = stateGreeting;
        }
    }
}
