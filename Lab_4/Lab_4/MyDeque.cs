using System;


namespace Лабораторная_работа__4
{
    public class MyDeque<T>
    {
        private T[] items;

        private int current = -1;
        public int Count => current;

        private readonly int size = 10;

        public MyDeque(int size = 10)
        {
            this.size = size;
            items = new T[size];
            current = 0;

        }
        public MyDeque(T data, int size)
        {
            this.size = size;
            items = new T[size];
            items[0] = data;
            current = 1;
        }

        public void PushBack(T data)
        {
            if (current < size - 1)
            {
                if (current == -1) current = 0;
                items[current] = data;

                current++;
            }
            else
            {
                throw new StackOverflowException("Стек переполнен");
            }
        }

        public void PushFront(T data)
        {
            if (current < size - 1)
            {
                if (current == -1) current = 0;
                for (int i = current; i > 0; i--)
                {
                    items[i] = items[i - 1];
                }

                items[0] = data;
                current++;

            }
            else
            {
                throw new StackOverflowException("Стек переполнен");
            }
        }

        public T PopBack()
        {

            if (current >= 0)
            {
                var item = items[current - 1];
                current--;
                return item;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }

        public T PopFront()
        {
            if (current >= 0)
            {
                var item = items[0];
                for (int i = 0; i < Count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                current--;
                return item;
            }
            else
            {
                return default(T);//throw new NullReferenceException("Стек пуст");
            }
        }

        public T PeekBack()
        {
            return items[current - 1];
        }

        public T PeekFront()
        {
            return items[0];
        }

        public void WriteDeque()
        {
            for (int i = 0; i < current; i++)
            {
                Console.WriteLine(items[i]);
            }
        }

        public void PrintDec()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}