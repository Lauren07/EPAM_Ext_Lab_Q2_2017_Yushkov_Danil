using System;
using System.Collections.Generic;

namespace Task02
{
    public class Office : IObservable
    {
        private List<IObserver> persons;

        public event EventHandler<PersonEventArgs> PersonsHandler;

        public Office()
        {
            this.persons = new List<IObserver>();
        }

        public void AddPerson(Person person, DateTime time)
        {
            this.WriteSatePerson(person, StateGreeting.Hello);
            this.PersonsHandler?.Invoke(person, new PersonEventArgs(time, StateGreeting.Hello));
            this.RegisterObserver(person);
            this.persons.Add(person);
        }

        public void DeletePerson(Person person)
        {
            if (!this.persons.Contains(person))
            {
                return;
            }

            this.WriteSatePerson(person, StateGreeting.Bye);
            this.RemoveObserver(person);
            this.persons.Remove(person);
            this.PersonsHandler?.Invoke(person, new PersonEventArgs(StateGreeting.Bye));
        }

        private void WriteSatePerson(Person person, StateGreeting state)
        {
            if (state == StateGreeting.Hello)
            {
                Console.WriteLine($"\n[На работу пришел {person.Name}]");
            }
            else
            {
                Console.WriteLine($"\n[{person.Name} ушел домой]");
            }
        }

        public void RegisterObserver(IObserver obs)
        {
            this.PersonsHandler += obs.Update;
        }

        public void RemoveObserver(IObserver obs)
        {
            this.PersonsHandler -= obs.Update;
        }
    }
}
