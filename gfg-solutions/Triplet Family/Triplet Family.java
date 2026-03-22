class Solution {
    public boolean findTriplet(int[] arr) {
        int n = arr.length;

        // Iterate through each element as the potential third element
        for (int i = 0; i < n; i++) {
            HashSet<Integer> complements = new HashSet<>();

            // Iterate through the rest of the elements
            for (int j = 0; j < n; j++) {
                if (i != j) { // Ensure we don't use the same element
                    int required = arr[i] - arr[j];

                    // Check if the required complement exists
                    if (complements.contains(required))
                        return true;

                    // Add the current element to the set
                    complements.add(arr[j]);
                }
            }
        }
        return false;
    }
}