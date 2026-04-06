// Approach: HashMap counting. For each element, check how many previous elements equal (target - current).
// Time: O(n) Space: O(n)
class Solution {
    
    int countPairs(int arr[], int target) {
        HashMap<Integer, Integer> map = new HashMap<>();
        int count = 0;
        for (int i : arr) {
            int rem = target - i;
            if (map.containsKey(rem))
                count += map.get(rem);
            map.put(i, map.getOrDefault(i, 0) + 1);
        }
        return count;
    }
}