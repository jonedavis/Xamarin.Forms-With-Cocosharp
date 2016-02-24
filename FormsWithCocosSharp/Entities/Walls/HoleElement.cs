using System;
using CocosSharp;

namespace FormsWithCocosSharp
{
    public class HoleElement : WallElementBase
    {
        public HoleElement(WallPosition position) : base(position) { }


        protected override CCDrawNode Draw()
        {
            var node = new CCDrawNode();
            node.DrawRect(new CCRect(0, 0, 20, this.Height), GameColors.BackgroundColor4B);
            node.PositionX = this.Position == WallPosition.Left ? 0 : ScreenRight - 20;
            return node;
        }
    }
}