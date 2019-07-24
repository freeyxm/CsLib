using System;

namespace CsLib.Collections.BinaryTree
{
    public interface IBinaryTree<K, V>
    {
        bool Add(K key, V value);
        bool Remove(K key);
        bool ContainsKey(K key);
        void Clear();
        V this[K key] { get; set; }
        int Count { get; }

        void TraversePreOrder(Func<K, V, bool> action);
        void TraverseInOrder(Func<K, V, bool> action);
        void TraversePostOrder(Func<K, V, bool> action);
    }
}
