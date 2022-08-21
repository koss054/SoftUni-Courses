using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace E04.Froggy
{
    class Lake : IEnumerable<int>
    {
        private List<int> stoneNumbers;

        public Lake(List<int> stoneNumbers)
        {
            this.stoneNumbers = stoneNumbers;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stoneNumbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.stoneNumbers[i];
                }
            }
            for (int i = stoneNumbers.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stoneNumbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
