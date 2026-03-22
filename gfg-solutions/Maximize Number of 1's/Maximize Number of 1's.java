class Solution {
    public int maxOnes(int arr[], int k) {
        int left = 0, right = 0;
        int count = 0;

        for (; right < arr.length; right++) {
            if (arr[right] == 0)
                count++;
                
            if (count > k) {
                if (arr[left] == 0)
                    count--;
                left++;
            }
        }

        return right - left;
    }
}