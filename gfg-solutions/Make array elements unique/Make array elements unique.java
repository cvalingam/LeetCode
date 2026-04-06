// Approach: Sort array. Ensure each element is strictly greater than previous by incrementing and counting moves.
// Time: O(n log n) Space: O(1)
class Solution {
    public int minIncrements(int[] arr) {
        Arrays.sort(arr);

        HashSet<Integer> set = new HashSet<>();

        int sum = 0, max = 0;

        for (int i = 0; i < arr.length; i++) {
            max = Math.max(arr[i], max);

            if (set.contains(arr[i])) {
                sum += max + 1 - arr[i];
                max++;
                set.add(max);
            } else
                set.add(arr[i]);
        }

        return sum;
    }
}