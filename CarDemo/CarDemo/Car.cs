using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDemo
{
    public class Car
    {

        private readonly Brand brand;
        private readonly String name;
        private readonly int performance;

        public Car( Brand brand, String name, int performance )
        {
            this.brand = brand;
            this.name = name;
            this.performance = performance;
        }


        public override bool Equals(Object othat)
        {
            if (othat == this)
            {
                return true;
            }
            if (othat == null)
            {
                return false;
            }
            if (othat is Car)
            {
                Car that = (Car)othat;
                if ( this.brand == that.brand 
                    && this.performance == that.performance 
                    && this.name != null && this.name.Equals(that.name) ) {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Cantor (pair)
            return ( this.brand.GetHashCode() + this.performance ) * 13;
        }


        public override string ToString()
        {
            return brand + " " + name + " ("+performance+")";
        }

    }
}
