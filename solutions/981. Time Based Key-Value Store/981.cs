public class TimeMap
{
    private Dictionary<string, List<T>> map = new Dictionary<string, List<T>>();
    public TimeMap()
    {

    }

    public void Set(string key, string value, int timestamp)
    {
        if (!map.ContainsKey(key))
            map[key] = new List<T>();

        map[key].Add(new T(value, timestamp));
    }

    public string Get(string key, int timestamp)
    {
        if (!map.TryGetValue(key, out List<T> A))
            return "";

        int l = 0;
        int r = A.Count;

        while (l < r)
        {
            int m = (l + r) / 2;
            if (A[m].Timestamp > timestamp)
                r = m;
            else
                l = m + 1;
        }

        return l == 0 ? "" : A[l - 1].Value;
    }
}

public class T
{
    public string Value { get; set; }
    public int Timestamp { get; set; }

    public T(string value, int timestamp)
    {
        Value = value;
        Timestamp = timestamp;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */