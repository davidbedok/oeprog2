using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics
{
    public abstract class AbstractHolder : System.Object
    {

        private const int MAXIMUM_PEOPLE = 10;

        protected readonly int[] data;
        protected int index;
        protected int readIndex;

        public AbstractHolder()
        {
            this.data = new int[AbstractHolder.MAXIMUM_PEOPLE];
            this.index = 0;
        }

        public void addContent(int content)
        {
            this.checkWhileAdd(content);
            this.data[this.index++] = content;
        }

        protected abstract void checkWhileAdd(int content);

        public void initReading()
        {
            this.readIndex = 0;
        }

        public int read()
        {
            this.checkWhileRead();
            return this.data[this.readIndex++];
        }

        protected abstract void checkWhileRead();

    }
}
