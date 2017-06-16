using System;

namespace Task04
{
    public class Obstacle : GameObject
    {
        public int Durability { get; set; }

        public override void CheckConflicts(GameObject gameObj)
        {
            throw new NotImplementedException();
        }
    }
}
