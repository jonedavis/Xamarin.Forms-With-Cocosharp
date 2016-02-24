using System;
using CocosSharp;
using Xamarin.Forms;

namespace FormsWithCocosSharp
{
    public class GameStartLayer : CCLayerColor
    {
        private LayerDrawer _layerDrawer;


        public GameStartLayer () : base ()
        {
            this._layerDrawer = new LayerDrawer(this);

            var touchListener = new CCEventListenerTouchAllAtOnce ();
            touchListener.OnTouchesEnded = (touches, ccevent) =>
                {
                    var scene = new GameScene(this.GameView);
                    Game.Instance.IsPlaying = true;
                    this.GameView.Director.ReplaceScene(scene);
                };

            AddEventListener (touchListener, this);

            Color = GameColors.BackgroundColor;
            Opacity = 255;
        }


        protected override void AddedToScene ()
        {
            base.AddedToScene ();
            this._layerDrawer.AddScoreCircle();
            this._layerDrawer.AddBorders();
            this._layerDrawer.AddWind();
            this._layerDrawer.AddRect(true);
        }
    }
}