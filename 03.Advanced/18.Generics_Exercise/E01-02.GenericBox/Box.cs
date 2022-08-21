using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {     
        public List<T> Elements { get; set; }

        public Box()
        {
            Elements = new List<T>();
        }

        public void AddElement(T element)
        {
            Elements.Add(element);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in Elements)
            {
                sb.Append($"{typeof(T)}: {element}\n");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
