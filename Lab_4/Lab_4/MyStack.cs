using System;


namespace Лабораторная_работа__4
{
    public class MyStack<T>
    {
        T[] items;
        private int current = -1;
        private readonly int size = 10;

        public int Count => current;

        public MyStack(int size = 10)
        {
            this.size = size;
            items = new T[size];
            current = 0;
        }

        public MyStack(T data, int size = 10) : this(size)
        {
            items[0] = data;
            current = 1;
        }

        public void Push(T data)
        {
            if (current <= size - 1)
            {

                items[current] = data;
                current++;
            }
            else
            {
                throw new StackOverflowException("Стек переполнен");
            }
        }

        public T Pop()
        {
            if (current > 0)
            {
                current--;
                var item = items[current];
                return item;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }

        public T Peek()
        {
            if (current > 0)
            {
                return items[current - 1];
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }

    }
}