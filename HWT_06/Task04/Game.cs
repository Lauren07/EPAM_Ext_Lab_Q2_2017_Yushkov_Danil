using System;
using System.Collections.Generic;

namespace Task04
{
    public class Game
    {
        public bool GameOn;
        public GameObject[,] Map;
        private Player player;
        private IEnumerable<Enemy> enemies;

        public Game()
        {
            this.Map = new GameObject[GameConfig.HeightMap, GameConfig.WidthMap];
        }

        public void Start()
        {
          // TODO:while(GameOn)
        }

        public void Stop()
        { }

        private void InitMap()
        { }

        private bool CheckGameIsOver()
        {
            throw new NotImplementedException();
        }
    }
}
