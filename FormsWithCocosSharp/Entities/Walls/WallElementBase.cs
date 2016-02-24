using System;
using CocosSharp;

namespace FormsWithCocosSharp
{
    public abstract class WallElementBase : IDisposable
    {
        public event EventHandler BeforeDispose;
        public static float Velocity = 450;
        protected static int ScreenRight = 200;
        private static int ElementAtomicHeight = 54;


		protected int Height { get; private set; }
        

        public void IncrementHeight()
        {
            this.Height += ElementAtomicHeight;
        }


        public float VelocityY
        {
            get;
            set;
        }
        

		public WallPosition Position { get; private set; } 


        protected WallElementBase(WallPosition position)
        {
            this.Position = position;
            this.Height = ElementAtomicHeight;
        }


        void ApplyVelocity(float time)
        {
            this.Node.PositionY -= VelocityY * time;
            if (this.Node.PositionY < -this.Node.BoundingRect.Size.Height)
            {
                this.VelocityY = 0;
                this.BeforeDispose?.Invoke(this, EventArgs.Empty);
                this.Node.RemoveFromParent();
                this.Dispose();
            }
        }


        private CCDrawNode _node;
        public CCDrawNode Node
        {
            get
            {
                return this._node ?? (this._node = this.Draw());
            }
        }


        protected abstract CCDrawNode Draw();

        
		public void Schedule(CCLayer layer)
        {
            this.Node.AnchorPoint = CCPoint.AnchorLowerLeft;
            this.Node.PositionY = MyGameView.PageHeight;
            layer.AddChild(this.Node);
            this.VelocityY = Velocity;
            this.Node.Schedule (ApplyVelocity);
        }


        #region IDisposable implementation


        public void Dispose()
        {
            if (this._node != null)
            {
                this._node.RemoveFromParent();
                this._node.Dispose();
            }
        }

        #endregion
    }
}