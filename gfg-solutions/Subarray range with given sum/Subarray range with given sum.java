class Solution {
    // Function to count the number of subarrays which adds to the given sum.
    static int subArraySum(int arr[], int tar) {
        HashMap<Integer, Integer> sumFrequency = new HashMap<>();
        int cumulativeSum = 0;
        int count = 0;

        sumFrequency.put(0, 1);

        for (int num : arr) {
            cumulativeSum += num;

            if (sumFrequency.containsKey(cumulativeSum - tar))
                count += sumFrequency.get(cumulativeSum - tar);

            sumFrequency.put(cumulativeSum, sumFrequency.getOrDefault(cumulativeSum, 0) + 1);
        }

        return count;
    }
}