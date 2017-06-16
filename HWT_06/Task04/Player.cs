using System;
using System.Collections.Generic;

namespace Task04
{
    public class Player : GameObject
    {
        public Dictionary<string, int> Characteristics { get; private set; }

        public void TakeBonus(Bonus bonus)
        { }

        public void MakeMove(Coordinate newPoisition)
        { }

        public override void CheckConflicts(GameObject gameObj)
        {
            throw new NotImplementedException();
        }
    }
}
