using System;

namespace Task02
{
    public class PersonEventArgs : EventArgs
    {
        public DateTime Time { get; }

        public StateGreeting State { get; }

        public IOutput OutputWriter;

        public PersonEventArgs(DateTime time, StateGreeting stateGreeting, IOutput outputWriter)
        {
            this.Time = time;
            this.State = stateGreeting;
            this.OutputWriter = outputWriter;
        }

        public PersonEventArgs(StateGreeting stateGreeting, IOutput outputWriter)
        {
            this.State = stateGreeting;
            this.OutputWriter = outputWriter;
        }
    }
}
