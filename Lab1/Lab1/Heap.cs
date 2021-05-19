using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    class Piramida : IEnumerable
    {
        private List<int> items = new List<int>();
        public int Count => items.Count;


        public Piramida() { }

        public Piramida(List<int> items)
        {
            this.items.AddRange(items);
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        public int GetMax()
        {
            var result = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        private void Sort(int curentIndex)
        {
            int minIndex = curentIndex;
            int leftIndex;
            int rightIndex;

            while (curentIndex < Count)
            {
                leftIndex = 2 * curentIndex + 1;
                rightIndex = 2 * curentIndex + 2;

                if (leftIndex < Count && items[leftIndex] < items[minIndex])
                {
                    minIndex = leftIndex;
                }

                if (rightIndex < Count && items[rightIndex] < items[minIndex])
                {
                    minIndex = rightIndex;
                }

                if (minIndex == curentIndex)
                {
                    break;
                }

                Swap(curentIndex, minIndex);
                curentIndex = minIndex;
            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            int temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;
        }


        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return GetMax();
            }
        }
    }
}