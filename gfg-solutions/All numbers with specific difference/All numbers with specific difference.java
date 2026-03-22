class Solution {
    public int getCount(int n, int d) {
        int s = 1; // start
        int e = n; // end
        int temp = 0;

        // binary search to get that temp
        while (s <= e) {
            int mid = s + (e - s) / 2;
            if (mid - sumOfDig(mid) >= d) { // condition given
                temp = mid;
                e = mid - 1;
            } else
                s = mid + 1;
        }

        return temp == 0 ? 0 : n - temp + 1;
    }

    public int sumOfDig(int n) {
        int sum = 0;
        while (n > 0) {
            int dig = n % 10;
            sum += dig;
            n = n / 10;
        }
        
        return sum;
    }
};