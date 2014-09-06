using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChemistryDemo
{
    public class Shape
    {

        protected readonly ConsoleColor color;
        protected readonly int x;
        protected readonly int y;

        public Shape(ConsoleColor color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public virtual void put( Grid grid ) {
            grid.setColor(this.x, this.y, this.color);
        }

        public override string ToString()
        {
            return "[Shape] " + this.color + " ("+ this.x + ":" + this.y + ")";
        }

        public static Shape create(Random random, int maxX, int maxY)
        {
            Shape result = null;
            ConsoleColor color = Shape.getRandomColor(random);
            int x = random.Next(maxX);
            int y = random.Next(maxY);
            switch (random.Next(2))
            {
                case 0: result = new Shape(color, x, y); break;
                case 1: result = new ExtraShape(color, x, y, ExtraShape.getRandomDirection(random)); break;
            }
            return result;
        }

        private static ConsoleColor getRandomColor(Random random)
        {
            ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            ConsoleColor color = ConsoleColor.White;
            do
            {
                color = colors[random.Next(colors.Length)];
            } while (Grid.isForbiddenColors(color));
            return color;
        }

    }
}
