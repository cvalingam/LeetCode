class Solution {
    public boolean canSplit(int arr[]) {
        int sum = 0;
        for (int a : arr)
            sum += a;

        int temp = 0;
        for (int a : arr) {
            temp += a;
            if (temp == (sum - temp))
                return true;
        }

        return false;
    }
}