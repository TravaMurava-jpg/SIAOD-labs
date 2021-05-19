using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2.Folder
{
    //Map со случайным рехэшированием
    class Map2<TKey, TValue> : IEnumerable
    {
        private int size = 100;
        private ItemMap<TKey, TValue>[] Items;
        private List<TKey> Keys = new List<TKey>();

        public Map2()
        {
            Items = new ItemMap<TKey, TValue>[size];
        }

        public void Add(ItemMap<TKey, TValue> item)
        {
            var hash = GetHash(item.Key);

            if (Keys.Contains(item.Key))
            {
                return;
            }

            if (Items[hash] == null)
            {
                Keys.Add(item.Key);
                Items[hash] = item;
            }
            else
            {
                List<int> help = new List<int>();
                while (true)
                {
                    Random rand = new Random();
                    int NewHash = rand.Next(0, size - 1);
                    if (!help.Contains(NewHash))
                    {
                        help.Add(NewHash);
                    }
                    if (Items[NewHash] == null)
                    {
                        Items[NewHash] = item;
                        Keys.Add(item.Key);
                        break;
                    }

                    if (help.Count >= size - Items.Length)
                    {
                        throw new Exception("Словарь заполнен");
                    }

                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        public void Remove(TKey key)
        {
            var hash = GetHash(key);

            if (!Keys.Contains(key))
            {
                return;
            }


            if (Items[hash] != null && Items[hash].Key.Equals(key))
            {
                Items[hash] = null;
                Keys.Remove(key);
            }
            else
            {
                for (var i = 0; i < size; i++)
                {
                    if (Items[i] != null && Items[i].Key.Equals(key))
                    {
                        Items[i] = null;
                        Keys.Remove(key);
                        return;
                    }
                }
            }
        }

        public TValue Search(TKey key)
        {

            var hash = GetHash(key);

            if (!Keys.Contains(key))
            {
                return default(TValue);
            }


            if (Items[hash] != null && Items[hash].Key.Equals(key))
            {
                return Items[hash].Value;
            }
            else
            {
                foreach (var item in Items)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                return default(TValue);
            }
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }
    }
}