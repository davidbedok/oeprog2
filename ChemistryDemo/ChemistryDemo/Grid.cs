using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChemistryDemo
{
    public class Grid
    {

        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Black;
        private const ConsoleColor EXPLOSION_COLOR = ConsoleColor.Red;
        private const ConsoleColor FRAME_COLOR = ConsoleColor.White;
        private const int ANNIHILATION_PERCENT_LIMIT = 10;

        private readonly ConsoleColor[,] map;

        private ExplosionEvent explosion;

        private int MaxX
        {
            get { return map.GetLength(0); }
        }

        private int MaxY
        {
            get { return map.GetLength(1); }
        }

        private int Area
        {
            get { return this.MaxX * this.MaxY; }
        }

        public Grid( int width, int height )
        {
            this.map = new ConsoleColor[width,height];
            this.init();
        }

        private void init()
        {
            for (int i = 0; i < this.MaxX; i++)
            {
                for (int k = 0; k < this.MaxY; k++)
                {
                    this.map[i, k] = Grid.DEFAULT_COLOR;
                }
            }
        }

        public void bind(ExplosionEvent explosion)
        {
            this.explosion = explosion;
        }

        public void tick( Random random )
        {
            this.add(Shape.create(random, this.MaxX, this.MaxY));
        }

        public void add( Shape shape )
        {
            shape.put(this);
        }

        public void setColor(int x, int y, ConsoleColor color)
        {
            if (this.checkFrame(x,y))
            {
                if (this.checkExplosion(x,y,color))
                {
                    this.doExplosion(x, y);
                }
                else
                {
                    this.map[x, y] = color;
                }
            }
        }

        private bool checkFrame(int x, int y)
        {
            return x >= 0 && x < this.MaxX && y >= 0 && y < this.MaxY;
        }

        private bool checkExplosion( int x, int y, ConsoleColor color)
        {
            return this.map[x, y] != Grid.DEFAULT_COLOR && color != Grid.EXPLOSION_COLOR;
        }

        private void doExplosion( int x, int y)
        {
            if (this.explosion != null)
            {
                this.explosion.explosion(x, y);
            }
            this.doExplosionCross(x, y);
            this.checkAnnihilation();
        }

        private void doExplosionCross(int x, int y)
        {
            this.setColor(x - 1, y, Grid.EXPLOSION_COLOR);
            this.setColor(x + 1, y, Grid.EXPLOSION_COLOR);
            this.setColor(x, y, Grid.EXPLOSION_COLOR);
            this.setColor(x, y - 1, Grid.EXPLOSION_COLOR);
            this.setColor(x, y + 1, Grid.EXPLOSION_COLOR);
        }

        private void checkAnnihilation()
        {
            int percent = this.getExplodedAreaPercent();
            if (percent > Grid.ANNIHILATION_PERCENT_LIMIT)
            {
                throw new AnnihilationException("Exploded area percent: " + percent);
            }
        }

        private int getExplodedAreaPercent()
        {
            return (int)((double)this.getNumberOfExplodedFields() / this.Area * 100);
        }

        private int getNumberOfExplodedFields()
        {
            int count = 0;
            for (int i = 0; i < this.MaxX; i++)
            {
                for (int k = 0; k < this.MaxY; k++)
                {
                    if (this.map[i, k] == Grid.EXPLOSION_COLOR)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void print()
        {
            this.printFrame();
            for (int i = 0; i < this.MaxX; i++)
            {
                for (int k = 0; k < this.MaxY; k++)
                {
                    if (this.map[i, k] != Grid.DEFAULT_COLOR)
                    {
                        Console.SetCursorPosition(i + 1, k + 1);
                        Console.ForegroundColor = this.map[i, k];
                        Console.Write(this.getFieldChar(i,k));
                    }
                }
            }
        }

        private void printFrame()
        {
            Console.ForegroundColor = Grid.FRAME_COLOR;
            for (int i = 0; i < this.MaxX + 2; i++)
            {
                for (int k = 0; k < this.MaxY + 2; k++)
                {
                    if (this.isFrame(i, k))
                    {
                        Console.SetCursorPosition(i, k);
                        Console.Write('#');
                    }
                }
            }
        }

        private bool isFrame(int x, int y)
        {
            return x == 0 || x == this.MaxX + 1 || y == 0 || y == this.MaxY + 1;
        }

        public char getFieldChar(int x, int y)
        {
            return this.map[x, y] == Grid.EXPLOSION_COLOR ? 'X' : 'O';
        }

        public static bool isForbiddenColors(ConsoleColor color)
        {
            return color == Grid.DEFAULT_COLOR || color == Grid.EXPLOSION_COLOR || color == Grid.FRAME_COLOR;
        }

    }
}
