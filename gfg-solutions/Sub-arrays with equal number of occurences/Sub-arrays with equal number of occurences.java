// Approach: Replace: +1 for a, -1 for b. Find subarrays with sum 0 using prefix sum HashMap.
// Time: O(n) Space: O(n)
class Solution {
    
    static int sameOccurrence(int arr[], int x, int y) {
        int n = arr.length;
        int count = 0;
        int diff = 0;
        Map<Integer, Integer> map = new HashMap<>();
        map.put(0, 1);

        // Iterate over the array
        for (int i = 0; i < n; i++) {
            if (arr[i] == x)
                diff++;
            if (arr[i] == y)
                diff--;
            count += map.getOrDefault(diff, 0);
            map.put(diff, map.getOrDefault(diff, 0) + 1);
        }

        return count;
    }
}