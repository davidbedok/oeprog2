using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceStore.helper
{
    public class Size
    {
        public static readonly string UNIT = "mm";

        private double width; // szélesség
        private double height; // magasság
        private double length; // hosszúság

        public Size(double width, double height, double length)
        {
            this.width = width;
            this.height = height;
            this.length = length;
        }

        public override string ToString()
        {
            return this.width + "x" + this.length + "x" + this.height + "("+Size.UNIT+")";
        }
    }
}
