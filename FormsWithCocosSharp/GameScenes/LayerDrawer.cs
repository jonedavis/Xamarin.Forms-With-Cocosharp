using System;
using CocosSharp;

namespace FormsWithCocosSharp
{
    public class LayerDrawer
    {
        private CCLayer _layer;


        public LayerDrawer(CCLayer layer)
        {
            this._layer = layer;
        }

        
		public void AddBorders()
        {
            var height = MyGameView.PageHeight;

            var rect = new CCDrawNode();
            rect.DrawRect(new CCRect(0, 0, 20, height), GameColors.WallsColor4B);
            this._layer.AddChild(rect);

            rect = new CCDrawNode();
            rect.DrawRect(new CCRect(180, 0, 20, height), GameColors.WallsColor4B);
            this._layer.AddChild(rect);
        }


        public void AddScoreCircle()
        {
            /*
            var node = new CCDrawNode();
            node.DrawSolidCircle(new CCPoint(100, MyGameView.PageHeight - 53), 30, CCColor4B.White);
            this._layer.AddChild(node, 10);
            */
        }


        public void AddWind()
        {
            this._layer.Schedule(t => this.DrawWind(), 0.15f);
        }


        public Rect AddRect(bool stat = false)
        {
            var rect = new Rect(stat);
            this._layer.AddChild(rect, 8);
            return rect;
        }


        private void DrawWind()
        {
            for (int i = 0; i < 2; i++)
            {
                var windElement = new WindElement();
                this._layer.AddChild(windElement, 1);
            }
        }
    }
}