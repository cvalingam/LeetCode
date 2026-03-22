class Solution {
    // Function to find the smallest positive number missing from the array.
    public int missingNumber(int[] arr) {
        Set<Integer> set = new HashSet<>();
        for (int num : arr) {
            if (num > 0)
                set.add(num);
        }

        int smallNum = 1;
        while (set.contains(smallNum))
            smallNum++;

        return smallNum;
    }
}