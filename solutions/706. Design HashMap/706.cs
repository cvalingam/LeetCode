public class MyHashMap
{
    private const int kSize = 10000;
    private List<int[]>[] lists;

    public MyHashMap()
    {
        lists = new List<int[]>[kSize];
        for (int i = 0; i < kSize; ++i)
            lists[i] = new List<int[]>();
    }

    public void Put(int key, int value)
    {
        foreach (var pair in lists[key % kSize])
        {
            if (pair[0] == key)
            {
                pair[1] = value;
                return;
            }
        }
        lists[key % kSize].Add(new int[] { key, value });
    }

    public int Get(int key)
    {
        foreach (var pair in lists[key % kSize])
        {
            if (pair[0] == key)
                return pair[1];
        }
        
        return -1;
    }

    public void Remove(int key)
    {
        for (int i = 0; i < lists[key % kSize].Count; ++i)
        {
            if (lists[key % kSize][i][0] == key)
            {
                lists[key % kSize].RemoveAt(i);
                return;
            }
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */