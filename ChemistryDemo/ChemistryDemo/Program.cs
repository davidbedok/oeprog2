using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChemistryDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Program.testShape();
            // Program.testGridSetColor();
            // Program.testGridWithShape();
            Program.testSimulation();
            Console.ReadKey();
        }

        private static void testShape()
        {
            Shape shape = new Shape(ConsoleColor.Blue, 3, 7);
            Console.WriteLine(shape);
            Shape extraShape = new ExtraShape(ConsoleColor.DarkBlue, 8, 3, Direction.LEFT);
            Console.WriteLine(extraShape);
        }

        private static void testGridSetColor()
        {
            Grid grid = new Grid(20, 20);
            grid.setColor(4, 7, ConsoleColor.Green);
            grid.setColor(13, 19, ConsoleColor.Red);
            grid.print();
        }

        private static void testGridWithShape()
        {
            Grid grid = new Grid(20, 20);
            grid.add(new Shape(ConsoleColor.Blue, 4, 7));
            grid.add(new ExtraShape(ConsoleColor.Green, 8, 2, Direction.BOTTOM));
            grid.print();
        }

        private static void testSimulation()
        {
            Random random = new Random();
            Grid grid = new Grid(20, 20);
            grid.bind(new ExplosionHandler());
            try
            {
                while (true)
                {
                    grid.tick(random);
                    // Console.Clear();
                    grid.print();
                    // Console.ReadKey();
                }
            }
            catch (AnnihilationException e)
            {
                Console.SetCursorPosition(0, 23);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(e.Message);   
            }
        }

    }
}
