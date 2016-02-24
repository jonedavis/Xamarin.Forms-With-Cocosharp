using System;
using CocosSharp;
using System.Collections.Generic;

namespace FormsWithCocosSharp
{
    public class TeethElement : WallElementBase
    {
        public TeethElement(WallPosition position) : base(position) { }


        protected override CCDrawNode Draw()
        {
            var node = new CCDrawNode();

            var color = GameColors.WallsColor4B;

            var basisX = this.Position == WallPosition.Left ? 0 : 6;
            var vertexX = this.Position == WallPosition.Left ? 6 : 0;

            var numberOfTriangles = this.Height / 12;
            var triangles = new List<CCV3F_C4B>();

            for (int i = 0; i < numberOfTriangles; i++)
            {
                var y = i * 12;

                triangles.AddRange(new [] {
                    new CCV3F_C4B(new CCPoint(basisX, y), color),
                    new CCV3F_C4B(new CCPoint(vertexX, y + 12/2), color),
                    new CCV3F_C4B(new CCPoint(basisX, y + 12), color),
                });
            }
                
            node.DrawTriangleList(triangles.ToArray());
            node.PositionX = this.Position == WallPosition.Left ? 20 : ScreenRight - 26;

            return node;

        }
    }
}