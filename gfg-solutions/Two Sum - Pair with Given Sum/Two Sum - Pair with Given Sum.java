// Approach: HashSet approach: for each element check if (target - element) is in set.
// Time: O(n) Space: O(n)

class Solution {
    boolean twoSum(int arr[], int target) {
        HashMap<Integer, Integer> mm = new HashMap<>();
        for (int x : arr) {
            if (mm.get(target - x) != null)
                return true;
            mm.put(x, 1);
        }
        return false;
    }
}