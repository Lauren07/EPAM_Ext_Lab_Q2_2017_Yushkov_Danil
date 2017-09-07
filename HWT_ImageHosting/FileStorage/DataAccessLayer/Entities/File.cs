using System;

namespace DataAccessLayer.Entities
{
    public class File : IEquatable<File>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int UserId { get; set; }


        public bool Equals(File x)
        {
            if (Object.ReferenceEquals(x, null))
            {
                return false;
            }

            return x.Id == Id;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Id.GetHashCode();
        }
    }
}
