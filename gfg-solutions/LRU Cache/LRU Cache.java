class LRUCache {
    private static int capacity;
    private static LinkedHashMap<Integer, Integer> cache;

    // Constructor for initializing the cache capacity with the given value.
    LRUCache(int cap) {
        capacity = cap;
        cache = new LinkedHashMap<>(cap, 0.75f, true) {
            @Override
            protected boolean removeEldestEntry(Map.Entry<Integer, Integer> eldest) {
                return size() > capacity;
            }
        };
    }

    // Function to return value corresponding to the key.
    public static int get(int key) {
        return cache.getOrDefault(key, -1);
    }

    // Function for storing key-value pair.
    public static void put(int key, int value) {
        cache.put(key, value);
    }
}
