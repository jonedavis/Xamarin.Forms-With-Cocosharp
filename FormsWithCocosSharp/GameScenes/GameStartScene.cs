using System;

using Xamarin.Forms;
using CocosSharp;

namespace FormsWithCocosSharp
{
	public class GameStartScene : CCScene
	{
		public GameStartScene (CCGameView gameView) : base(gameView)
		{
            this.AddLayer(new GameStartLayer());
		}
	}
}