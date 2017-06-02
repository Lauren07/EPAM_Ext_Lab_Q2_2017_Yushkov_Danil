namespace Task06
{
    public class TextParameter
    {
        public string Name { get; }

        public bool IsEnable { get; set; }

        public TextParameter(string name)
        {
            this.Name = name;
            this.IsEnable = false;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
