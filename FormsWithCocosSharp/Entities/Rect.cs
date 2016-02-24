using System;
using CocosSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsWithCocosSharp
{
    public class Rect : CCDrawNode
    {
        private static int MaxLeftPosition = 20;
        private static int MaxRightPosition = 160;

        public Rect(bool stat = false)
        {
            var rect = new CCRect(0, 0, 20, 20);

            //this.AnchorPoint = CCPoint.AnchorMiddle;
            this.DrawRect(rect, GameColors.RectColor);
            this.PositionX = 20;
            this.PositionY = Math.Min(90, MyGameView.PageHeight - 200);

            if (!stat)
            {
                var touchListener = new CCEventListenerTouchAllAtOnce();
                touchListener.OnTouchesBegan = OnTouchesBegun;

                AddEventListener(touchListener, this);
            }
        }


        private bool _isMovingInProgress = false;


        private async void OnTouchesBegun(List<CCTouch> arg1, CCEvent arg2)
        {
            var x = (int)this.PositionX == (int)MaxRightPosition ? MaxLeftPosition : MaxRightPosition;
            await this.MoveTo(x);
        }


        public async void MoveRight()
        {
            await this.MoveTo(MaxRightPosition);
        }

        private async Task MoveTo(int x, float duration = .05f)
        {
            if (_isMovingInProgress)
                return;
            
            Game.Instance.Jumps++;
            this._isMovingInProgress = true;

            var moveRectangle = new CCMoveTo (duration, new CCPoint(x, this.PositionY));
            await this.RunActionsAsync(moveRectangle);

            this.Explode(2);
            this.AddScore();
            this._isMovingInProgress = false;
        }


        private void AddScore()
        {
            Game.Instance.CurrentScore++;
        }


        private void Explode (int particles, bool blendAdditive = false)
        {
            var explosion = new CCParticleExplosion (this.Position);
            explosion.TotalParticles = particles;
            explosion.AutoRemoveOnFinish = true;
            explosion.StartColor = new CCColor4F(GameColors.RectColor);
            explosion.EndColor = new CCColor4F(GameColors.RectColor);
            explosion.BlendAdditive = blendAdditive;
            this.Parent.AddChild (explosion);
        }
         

        public bool CheckCollisionAsync(IEnumerable<WallElementBase> walls)
        {
			if (!walls.Any(w => this.BoundingBox.IntersectsRect(w.Node.BoundingBox))) return false;

            Game.Instance.CurrentScore = 0;
            Game.Instance.Deaths++;
            this._isMovingInProgress = true;
            this.Explode(50, true);
            this.RemoveFromParent();
            this._isMovingInProgress = false;
            return true;
        }
    }
}