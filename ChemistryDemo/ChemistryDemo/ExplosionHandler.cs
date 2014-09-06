using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChemistryDemo
{
    public class ExplosionHandler : ExplosionEvent
    {

        private List<String> events;

        public ExplosionHandler()
        {
            this.events = new List<String>();
        }

        public void explosion( int x, int y ) {
            this.events.Add("Explosion ("+x+":"+y+")");
            this.print();
        }

        private void print()
        {
            Console.ForegroundColor = ConsoleColor.White;
            int top = 0;
            foreach ( String line in this.events ) {
                Console.SetCursorPosition(30, top);
                Console.Write(line);
                top++;
            }
        }

    }
}
