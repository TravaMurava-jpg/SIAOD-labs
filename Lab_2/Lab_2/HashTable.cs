using System;


namespace Lab2.Folder
{
    class HashTable<T>
    {
        //хэш таблица в которой коллизии решаются методом цепочек

        private ItemHashTable<T>[] items;

        public HashTable(int size)
        {
            items = new ItemHashTable<T>[size];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ItemHashTable<T>(i);
            }
        }

        public void Add(T item)
        {
            var key = GetHash(item);
            items[key].Nodes.Add(item);
        }

        public void Delate(T item)
        {
            var key = GetHash(item);
            int index = items[key].Nodes.IndexOf(item);
            items[key].Nodes.RemoveAt(index);
        }

        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key].Nodes.Contains(item);
        }

        private int GetHash(T item)
        {
            return item.GetHashCode() % items.Length;
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Nodes.Count != 0)
                {
                    Console.Write("Key : " + items[i].Key + " Values: ");
                    for (int j = 0; j < items[i].Nodes.Count; j++)
                    {
                        Console.Write(items[i].Nodes[j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}