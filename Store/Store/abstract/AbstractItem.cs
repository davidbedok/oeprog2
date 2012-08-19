using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{

    public abstract class AbstractItem : System.Object {

        private string name;
        private int grid;
        private double price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public AbstractItem(string name, int grid, double price)
        {
            this.name = name;
            this.grid = grid;
            this.price = price;
        }      

        public string handle()
        {
            return this.play();
        }

        public abstract string play();        

    }

}
