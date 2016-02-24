using System;

namespace FormsWithCocosSharp
{
    public static class DataProvider
    {
        public static readonly string[][] Data = new []
            {
                new [] {
                    "x  x",
                    "x   ",
                    "x   ",
                    "x  x",
                    "   x",
                    "   x",
                    "x  x",
                },
                new [] {
                    "x  x",
                    "x   ",
                    "x  x",
                    "x  x",
                    "   x",
                    "x  x",
                },
                new [] {
                    "x  x",
                    "x   ",
                    "x   ",
                    "x   ",
                    "x  x",
                    "x> x",
                    "x> x",
                    "x> x",
                    "x  x",
                    "   x",
                    "x  x",
                },
                new [] { 
                    "x  x",
                    "x <x",
                    "x <x",
                    "x  x",
                    "x> x",
                    "x> x",
                    "x  x",
                },
                new [] {
                    "x  x",
                    "x <x",
                    "x <x",
                    "x <x",
                    "x  x",
                    "x  x",
                },
                new [] {
                    "x  x",
                    "x> x",
                    "x> x",
                    "x  x",
                    "x  x",
                    "x  x",
                },
                new [] {
                    "x  x",
                    "x   ",
                    "x   ",
                    "x   ",
                    "x  x",
                    "x> x",
                    "x> x",
                    "x> x",
                    "x  x",
                    "x  x",
                }
            };


        public static WallElementBase Parse(string elementStr)
        {
            switch (elementStr)
            {
                case "x> x":
                    return new TeethElement(WallPosition.Left);
                case "x <x":
                    return new TeethElement(WallPosition.Right);
                case "x   ":
                    return new HoleElement(WallPosition.Right);
                case "   x":
                    return new HoleElement(WallPosition.Left);
                default:
                    return null;
            }

        }
    }
}