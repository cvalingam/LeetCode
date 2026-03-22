import java.util.*;

class Solution {
    ArrayList<Integer> removeDuplicate(int arr[]) {
        HashSet<Integer> seen = new HashSet<>();
        ArrayList<Integer> result = new ArrayList<>();
        for (int num : arr) {
            // If the element is not in the set, add it to both the set and the result list
            if (!seen.contains(num)) {
                seen.add(num);
                result.add(num);
            }
        }

        return result;
    }
}