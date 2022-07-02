using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BooksApp.Model
{
    public class Grouping<K,T>: ObservableCollection<T>
    {
        public K Key { get; set; }
        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
