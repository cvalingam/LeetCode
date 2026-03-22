class Solution {
    // Function to determine if array arr can be split into three equal sum sets.
    public List<Integer> findSplit(int[] arr) {
        List<Integer> result = new ArrayList<>(Arrays.asList(-1, -1));
        int totalSum = 0;

        for (int num : arr)
            totalSum += num;

        if (totalSum % 3 != 0)
            return result;

        int targetSum = totalSum / 3;
        int currentSum = 0;
        int firstIndex = -1, secondIndex = -1;

        for (int i = 0; i < arr.length; i++) {
            currentSum += arr[i];

            if (currentSum == targetSum && firstIndex == -1)
                firstIndex = i;

            else if (currentSum == 2 * targetSum && firstIndex != -1) {
                secondIndex = i;
                result.set(0, firstIndex);
                result.set(1, secondIndex);
                return result;
            }
        }

        return result;
    }
}