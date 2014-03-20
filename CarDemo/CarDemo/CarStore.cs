using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDemo
{
    public class CarStore
    {

        private readonly Dictionary<Car, Int32> items;

        public CarStore()
        {
            this.items = new Dictionary<Car, Int32>();
        }

        private void add( Car car, int count )
        {
            if (this.items.ContainsKey(car))
            {
                this.items[car] += count;
            }
            else
            {
                this.items.Add(car, count);
            }
        }

        public void add(Brand brand, String name, int performance, int count)
        {
            this.add(new Car(brand, name, performance), count);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(50);
            foreach ( KeyValuePair<Car, Int32> pair in this.items) {
                info.Append(pair.Key).Append(" - count: ").Append(pair.Value);
                info.AppendLine();
            }
            return info.ToString();
        }

    }
}
