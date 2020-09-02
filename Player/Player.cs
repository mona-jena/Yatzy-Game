using System;
using YatzyKata;

namespace YatxyKata
{
    class Player
    {
        public Player()
        {
            IConsole consoleActions = new ConssoleActions();
            IRandom random = new Rng();
            YatzyGame player = new YatzyGame(consoleActions, random);
        }
    }
}