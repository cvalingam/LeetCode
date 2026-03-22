import java.util.*;

class Solution {
    public String findLargest(int[] arr) {
        int n = arr.length;
        String[] nums = new String[n];

        for (int i = 0; i < n; i++)
            nums[i] = Integer.toString(arr[i]);

        Arrays.sort(nums, (a, b) -> (b + a).compareTo(a + b));

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
            sb.append(nums[i]);

        String ans = sb.toString();
        if (ans.charAt(0) == '0')
            return "0";

        return ans;
    }
}