using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapImplementation
{
    public class StudentCatalog
    {

        private Dictionary<Person, List<Mark>> marks;

        public StudentCatalog()
        {
            this.marks = new Dictionary<Person, List<Mark>>();
        }

        #region Simple way (but not good enough)

        private void addNewCatalogItem(Person key, List<Mark> value)
        {
            this.marks.Add(key, value);
        }

        private void addExistsCatalogItem(Person key, List<Mark> value)
        {
            this.marks[key] = value;
        }

        protected void addCatalogItem(Person key, List<Mark> value)
        {
            if (this.marks.ContainsKey(key))
            {
                this.addExistsCatalogItem(key,value);
            }
            else
            {
                this.addNewCatalogItem(key, value);
            }
        }

        #endregion

        #region Practicable way

        private void addNewValueToNewKey(Person key, Mark mark)
        {
            List<Mark> value = new List<Mark>();
            value.Add(mark);
            this.marks.Add(key, value);
        }

        private void addNewValueToExistsKey(Person key, Mark mark)
        {
            this.marks[key].Add(mark);
            /*
            List<Mark> origValue = this.marks[key];
            origValue.Add(mark);
            */
        }

        protected void addNewMark(Person key, Mark mark)
        {
            if (this.marks.ContainsKey(key))
            {
                this.addNewValueToExistsKey(key, mark);
            }
            else
            {
                this.addNewValueToNewKey(key,mark);
            }
        }

        #endregion

        #region Wrapped entities

        private Person findPerson(string neptunCode)
        {
            Person ret = null;
            List<Person> keys = new List<Person>(this.marks.Keys);
            IEnumerator<Person> iterator = keys.GetEnumerator();
            bool find = false;
            while (iterator.MoveNext() && !find)
            {
                Person person = iterator.Current;
                if (person.NeptunCode.Equals(neptunCode))
                {
                    ret = person;
                    find = true;
                }
            }
            return ret;
        }

        public void addNewPerson(string name, string neptunCode, DateTime birthDate)
        {
            // Ha nincs a Person-ban Equals es GetHashCode override-olva.
            /*
            if (this.findPerson(neptunCode) == null)
            {
                this.marks.Add(new Person(name, neptunCode, birthDate), new List<Mark>());
            }
            */

            // Ha van..
            try
            {
                this.marks.Add(new Person(name, neptunCode, birthDate), new List<Mark>());
            }
            catch (ArgumentException e)
            {
                System.Console.WriteLine("The neptunCode (" + neptunCode + ") is already in use. " + e.Message);
                // value is null --> valid
                // this.marks.Add(new Person("dsdf","frfger",new DateTime(2000,01,01)), null);
                
                // key is null --> not valid
                // this.marks.Add(null, new List<Mark>());
            }
        }

        public void addNewMark(string neptunCode, int percent, string comment)
        {
            Person person = this.findPerson(neptunCode);
            if (person != null)
            {
                this.addNewMark(person, new Mark(percent, comment));
            }
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<Person, List<Mark>> entry in this.marks)
            {
                Person person = entry.Key;
                List<Mark> personMarks = entry.Value;
                sb.AppendLine("# "+person+"'s mark(s):");
                if (personMarks != null)
                {
                    foreach (Mark mark in personMarks)
                    {
                        sb.AppendLine("- " + mark);
                    }
                }
            }
            return sb.ToString();
        }

    }
}
