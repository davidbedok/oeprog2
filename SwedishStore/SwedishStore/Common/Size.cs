using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwedishStore.Common
{
    public class Size
    {

        public const String UNIT = "cm";

        private readonly double width;
        private readonly double height;
        private readonly double length;

        public Size(double width, double height, double length)
        {
            this.width = width;
            this.height = height;
            this.length = length;
        }

        public double getHeight()
        {
            return this.height;
        }

        public double getLength()
        {
            return this.length;
        }

        public double getWidth()
        {
            return this.width;
        }

        public double getSurface()
        {
            return this.width * this.length;
        }

        private String formatValue(double value)
        {
            return String.Format("{0:0}", value);
        }

        public override String ToString()
        {
            return this.formatValue(this.width) + "x" + this.formatValue(this.height) + "x" + this.formatValue(this.length) + " (" + Size.UNIT + ")";
        }

        public static Size fromString(String widthStr, String heightStr, String lengthStr)
        {
            double width = Double.Parse(widthStr);
            double height = Double.Parse(heightStr);
            double length = Double.Parse(lengthStr);
            return new Size(width, height, length);
        }
        
        public override bool Equals(Object othat)
        {
            // ------------------------------------------ 
            // use this part OR override == operator
            // if (this == othat)
            // {
            //    return true;
            // }
            // ------------------------------------------ 

            if (othat == null)
            {
                return false;
            }
            if (othat is Size)
            {
                Size that = othat as Size;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(Size that)
        {
            if ((object)that == null)
            {
                return false;
            }
            if (that.width == this.width && that.height == this.height && that.length == this.length)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 13 * (int)width;
        }
        
        public static bool operator ==(Size left, Size right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !(left == right);
        }
        
    }
}
