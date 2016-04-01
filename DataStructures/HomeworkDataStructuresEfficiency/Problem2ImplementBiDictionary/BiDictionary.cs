namespace Problem2ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BiDictionary<K1, K2, T>
    {
        private readonly Dictionary<K1, List<T>> valuesByFirstKey;
        private readonly Dictionary<K2, List<T>> valuesBySecondKey;
        private readonly Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                this.valuesByFirstKey.Add(key1, new List<T>());
            }

            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey.Add(key2, new List<T>());
            }

            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                this.valuesByBothKeys.Add(tuple, new List<T>());
            }

            this.valuesByFirstKey[key1].Add(value);
            this.valuesBySecondKey[key2].Add(value);
            this.valuesByBothKeys[tuple].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            List<T> results;
            this.valuesByBothKeys.TryGetValue(tuple, out results);

            return results ?? Enumerable.Empty<T>();
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            List<T> results;
            this.valuesByFirstKey.TryGetValue(key1, out results);

            return results ?? Enumerable.Empty<T>();
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            List<T> results;
            this.valuesBySecondKey.TryGetValue(key2, out results);

            return results ?? Enumerable.Empty<T>();
        }

        public bool Remove(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            bool isDeleted = false;
            

            if (this.valuesByBothKeys.ContainsKey(tuple))
            {
                isDeleted = true;
                var forDelete = this.valuesByBothKeys[tuple];
                foreach (var value in forDelete)
                {
                    this.valuesByFirstKey[key1].Remove(value);
                    this.valuesBySecondKey[key2].Remove(value);
                }

                this.valuesByBothKeys.Remove(tuple);
            }

            return isDeleted;
        }
    }
}
