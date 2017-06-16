namespace Task04
{
    public abstract class GameObject
    {
        public string ImagePath { get; }

        public string Name { get; }

        public Coordinate Position { get; set; }

        public int Priority { get; }

        public abstract void CheckConflicts(GameObject gameObj);
    }
}
