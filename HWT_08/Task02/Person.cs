using System;

namespace Task02
{
    public class Person : IObserver
    {
        public string Name { get; }

        public Person(string name)
        {
            this.Name = name;
        }

        public void SayHello(Person person, DateTime time)
        {
            if (person == null)
            {
                return;
            }

            Console.WriteLine($"'{this.GetGreeting(time)}, {person.Name}!', - сказал {this.Name}.");//todo pn у отдельного класса бизнес логики не должно быть зависимости от класса вывода данных.
        }

        public void SayBye(Person person)
        {
            if (person == null)
            {
                return;
            }

            Console.WriteLine($"'До свидания, {person.Name}', - сказал {this.Name}.");
        }

        private string GetGreeting(DateTime time)
        {
            if (time.Hour < 12)//todo pn хардкод
            {
                return GreetingsPhrases.Morning;
            }

            if (time.Hour < 17)
            {
                return GreetingsPhrases.Afternoon;
            }

            return GreetingsPhrases.Evening;
        }

        public void Update(object sender, PersonEventArgs args)
        {
            if (args.State == StateGreeting.Hello)
            {
                this.SayHello((Person)sender, args.Time);
            }
            else
            {
                this.SayBye((Person)sender);
            }
        }
    }
}
