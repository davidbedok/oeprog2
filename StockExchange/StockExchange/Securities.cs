using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class Securities
    {
        private readonly SecuritiesName name;
        private int value;
        private readonly List<ValueChangeEvent> events;

        public SecuritiesName Name
        {
            get { return this.name; }
        }

        public int Value
        {
            get { return this.value; }
        }

        public Securities(SecuritiesName name, int value)
        {
            this.name = name;
            this.value = value;
            this.events = new List<ValueChangeEvent>();
        }

        public void bind(ValueChangeEvent valueChangeEvent) {
            this.events.Add(valueChangeEvent);
        }

        public void modify(int changeValue)
        {
            if (value + changeValue <= 0)
            {
                throw new InvalidChangeException("Value cannot be non-positive. " + this.ToString());
            }
            this.value += changeValue;
            foreach (ValueChangeEvent valueChangeEvent in this.events)
            {
                valueChangeEvent.change(this.value);
            }
        }

        public override string ToString()
        {
            return "[Securities] " + this.name + " value: " + this.value;
        }

    }
}
