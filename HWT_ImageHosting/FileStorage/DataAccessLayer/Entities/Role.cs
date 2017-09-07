namespace DataAccessLayer.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Role(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Role(int id)
        {
            Id = id;
        }
    }
}
