public class LFUCache
{
    private int capacity;
    private int minFreq = 0;
    private Dictionary<int, int> keyToVal = new Dictionary<int, int>();
    private Dictionary<int, int> keyToFreq = new Dictionary<int, int>();
    private Dictionary<int, LinkedList<int>> freqToLRUKeys = new Dictionary<int, LinkedList<int>>();

    public LFUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (!keyToVal.ContainsKey(key))
            return -1;

        int freq = keyToFreq[key];
        freqToLRUKeys[freq].Remove(key);
        if (freq == minFreq && freqToLRUKeys[freq].Count == 0)
        {
            freqToLRUKeys.Remove(freq);
            ++minFreq;
        }

        // Increase key's freq by 1
        // Add this key to next freq's list
        PutFreq(key, freq + 1);
        return keyToVal[key];
    }

    public void Put(int key, int value)
    {
        if (capacity == 0)
            return;
        if (keyToVal.ContainsKey(key))
        {
            keyToVal[key] = value;
            Get(key); // Update key's count
            return;
        }

        if (keyToVal.Count == capacity)
        {
            // Evict an LRU key from `minFreq` list.
            int keyToEvict = freqToLRUKeys[minFreq].First.Value;
            freqToLRUKeys[minFreq].RemoveFirst();
            keyToVal.Remove(keyToEvict);
        }

        minFreq = 1;
        PutFreq(key, minFreq);    // Add new key and freq
        keyToVal[key] = value;    // Add new key and value
    }

    private void PutFreq(int key, int freq)
    {
        keyToFreq[key] = freq;
        if (!freqToLRUKeys.ContainsKey(freq))
        {
            freqToLRUKeys[freq] = new LinkedList<int>();
        }
        freqToLRUKeys[freq].AddLast(key);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */