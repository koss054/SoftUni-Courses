using System;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var bag = new OrderedBag<int>();
            bag.AddMany(cookies);

            var currentMinSweetness = bag[0];
            var steps = 0;

            while (currentMinSweetness < minSweetness && bag.Count > 1)
            {
                int leastSweetCookie = bag.RemoveFirst();
                int secondCookie = bag.RemoveFirst();
                int newCookie = leastSweetCookie + (2 * secondCookie);

                bag.Add(newCookie);
                currentMinSweetness = bag.GetFirst();
                steps++;

            }

            return currentMinSweetness < minSweetness ? -1 : steps;
        }
    }
}
