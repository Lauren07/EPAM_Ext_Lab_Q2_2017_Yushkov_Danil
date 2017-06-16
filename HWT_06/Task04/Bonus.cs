using System;

namespace Task04
{
    public class Bonus : GameObject
    {
        public int Value { get; set; }

        public override void CheckConflicts(GameObject gameObj)
        {
            throw new NotImplementedException();
        }
    }
}
