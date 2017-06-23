namespace Task01
{
    public class Person
    {
        public string Name { private set; get; }

        public Person(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
