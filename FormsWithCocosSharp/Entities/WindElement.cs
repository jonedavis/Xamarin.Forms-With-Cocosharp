using System;
using CocosSharp;

namespace FormsWithCocosSharp
{
    public class WindElement : CCDrawNode
    {
        private static Random Rand = new Random();


        public WindElement()
        {
            this.Opacity = 20;
            this.DrawRect(new CCRect(0, 0, 4, Rand.Next(54, 100)), GameColors.LightGrayColor4B);
            this.PositionX = Rand.Next(200);
            this.PositionY = MyGameView.PageHeight;
            this.Schedule(ApplyVelocity);
        }


        void ApplyVelocity(float time)
        {
            this.PositionY -= 700 * time;
            if (this.PositionY < -this.BoundingRect.Size.Height)
            {
                this.RemoveFromParent();
                this.Dispose();
            }
        }
    }
}