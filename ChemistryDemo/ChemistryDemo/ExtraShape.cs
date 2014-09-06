using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChemistryDemo
{
    public class ExtraShape : Shape
    {

        private readonly Direction direction;

        public ExtraShape(ConsoleColor color, int x, int y, Direction direction)
            : base(color, x, y)
        {
            this.direction = direction;
        }

        public override void put(Grid grid)
        {
            base.put(grid);
            switch (this.direction)
            {
                case Direction.LEFT: grid.setColor(this.x - 1, this.y, this.color); break;
                case Direction.RIGHT: grid.setColor(this.x + 1, this.y, this.color); break;
                case Direction.TOP: grid.setColor(this.x, this.y - 1, this.color); break;
                case Direction.BOTTOM: grid.setColor(this.x, this.y + 1, this.color); break;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.direction;
        }

        public static Direction getRandomDirection( Random random )
        {
            Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));
            return directions[random.Next(directions.Length)]; 
        }

    }
}
