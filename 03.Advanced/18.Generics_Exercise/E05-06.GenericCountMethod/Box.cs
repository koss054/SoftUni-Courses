﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
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

        public int Count(T comparedElement)
        {
            int internalCounter = 0;

            foreach (var element in Elements)
            {
                if (element.CompareTo(comparedElement) > 0)
                {
                    internalCounter++;
                }
            }

            return internalCounter;
        }
        //public override string ToString()
        //{
        //    var sb = new StringBuilder();

        //    foreach (var element in Elements)
        //    {
        //        sb.Append($"{typeof(T)}: {element}\n");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public void Swap(int firstIndex, int secondIndex)
        //    => (Elements[firstIndex], Elements[secondIndex])
        //        = (Elements[secondIndex], Elements[firstIndex]);
    }
}
