using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd = new Random();

       public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }

            int index = rnd.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);

            return element;
        }
    }
}
