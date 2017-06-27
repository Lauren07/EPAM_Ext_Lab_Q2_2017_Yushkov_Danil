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

        public void SayHello(Person person, DateTime time, IOutput outputWriter)
        {
            if (person == null)
            {
                return;
            }

            var welcomePhrase = $"'{this.GetGreeting(time)}, {person.Name}!', - сказал {this.Name}.";
            outputWriter.WriteMessage(welcomePhrase); //todo pn у отдельного класса бизнес логики не должно быть зависимости от класса вывода данных.
        }

        public void SayBye(Person person, IOutput outputWriter)
        {
            if (person == null)
            {
                return;
            }

            var byePhrase = $"'До свидания, {person.Name}', - сказал {this.Name}.";
            outputWriter.WriteMessage(byePhrase);
        }

        private string GetGreeting(DateTime time)
        {
            int hourMorning = 12, hourAfternoon = 17;
            if (time.Hour < hourMorning)
            {
                return GreetingsPhrases.Morning;
            }

            if (time.Hour < hourAfternoon)
            {
                return GreetingsPhrases.Afternoon;
            }

            return GreetingsPhrases.Evening;
        }

        public void Update(object sender, PersonEventArgs args)
        {
            if (args.State == StateGreeting.Hello)
            {
                this.SayHello((Person)sender, args.Time, args.OutputWriter);
            }
            else
            {
                this.SayBye((Person)sender, args.OutputWriter);
            }
        }
    }
}
