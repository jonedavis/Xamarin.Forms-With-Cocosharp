using System;
using CocosSharp;

namespace FormsWithCocosSharp
{
    public class GameScene : CCScene
    {
        public GameScene (CCGameView gameView) : base(gameView)
        {
            this.AddLayer(new GameLayer());
        }
    }
}