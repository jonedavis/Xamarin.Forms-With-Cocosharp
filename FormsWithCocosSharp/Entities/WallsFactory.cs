using System;
using System.Collections.Generic;
using System.Linq;

namespace FormsWithCocosSharp
{
    public class WallsFactory
    {
        private readonly List<WallElementBase> _level = new List<WallElementBase>();


        public WallsFactory()
        {
            var random = new Random();
            var dataCount = DataProvider.Data.Count();

            for(int i=0; i<200; i++)
            {
                var patternIndex = random.Next(dataCount - 1);

                var currentStr = string.Empty;
                WallElementBase currentElement = null;
                foreach (var item in DataProvider.Data[patternIndex])
                {
                    if (currentStr == item)
                    {
                        this._level.Add(null);
                        if (currentElement != null)
                            currentElement.IncrementHeight();
                    }
                    else
                    {
                        currentElement = DataProvider.Parse(item); 
                        this._level.Add(currentElement);
                    }
                    currentStr = item;
                }
            }
        }


        static int i = 0;


        public WallElementBase GetNext()
        {
            var element = this._level.ElementAt(i++);
            if (i > this._level.Count() - 1)
                i = 0;

            return element;
        }
    }
}