// Approach: Compute how many elements from the given array fall in each query range using binary search.
// Time: O((n + q) log n) Space: O(1)
import java.util.*;

class Solution {
    public ArrayList<Integer> missingRange(int[] arr, int low, int high) {
        ArrayList<Integer> ans = new ArrayList<>();
        HashSet<Integer> set = new HashSet<>();
        for (int i : arr)
            set.add(i);
        
        for (int i = low; i <= high; ++i) {
            if (!set.contains(i))
                ans.add(i);
        }
        return ans;
    }
}