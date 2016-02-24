using System;
using CocosSharp;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FormsWithCocosSharp
{
    public class GameLayer : CCLayerColor
    {
        private WallsFactory _wallsFactory;
        private LayerDrawer _layerDrawer;
        private readonly List<WallElementBase> _visibleWalls = new List<WallElementBase>();


        public GameLayer()
        {
            this._layerDrawer = new LayerDrawer(this);
            this._wallsFactory = new WallsFactory();
            Color = GameColors.BackgroundColor;
            Opacity = 255;
        }


        protected override void AddedToScene()
        {
            base.AddedToScene();

            this._layerDrawer.AddBorders();
            this._layerDrawer.AddWind();
            this._layerDrawer.AddScoreCircle();
            var rect = this._layerDrawer.AddRect();

            this.Schedule(t => this.DrawWalls(), 0.15f);
            this.Schedule(t => CheckCollision(rect));

            rect.MoveRight();
        }


        private void DrawWalls()
        {
            var walls = this._wallsFactory.GetNext();
            if (walls != null)
            {
                walls.Schedule(this);
                this._visibleWalls.Add(walls);
                walls.BeforeDispose += (s, e) =>
                    {
                        var curWalls = s as WallElementBase;
                        this._visibleWalls.Remove(curWalls);
                    };
            }
        }


        private async Task GameOverAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            var scene = new GameStartScene(this.GameView);
            this.GameView.Director.ReplaceScene(scene);
            Game.Instance.IsPlaying = false;
        }


        private void CheckCollision (Rect rect)
        {
            if (!this.Children.Contains(rect)) return;

            if (rect.CheckCollisionAsync(this._visibleWalls))
            {
                this.GameOverAsync();
            }
        }
    }
}