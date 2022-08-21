using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack()
        {
            this.elements = new List<T>();
        }
        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                this.elements.Add(element);
            }
        }

        public void Pop()
        {
            if (this.elements.Count > 0)
            {
                this.elements.RemoveAt(this.elements.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }
 
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
