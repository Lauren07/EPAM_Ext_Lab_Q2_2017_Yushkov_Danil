using System;

namespace DataAccessLayer
{
    public static class Randomizer
    {
        public static Random Random;

        static Randomizer()
        {
            Random = new Random();    
        }
    }
}
