namespace Task04
{
    public abstract class Enemy : GameObject
    {
        public int Damage { get; set; }

        public int Health { get; set; }

        public abstract Coordinate MakeMove();
    }
}
