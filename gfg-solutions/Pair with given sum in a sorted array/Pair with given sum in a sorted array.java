class Solution {

    int countPairs(int arr[], int target) {
        int st = 0;
        int ed = arr.length - 1;
        int count = 0;
        while (st < ed) {
            int sum = arr[st] + arr[ed];
            if (sum < target)
                st++;
            else if (sum > target)
                ed--;
            else {
                int cnt1 = 0, cnt2 = 0;
                int elem1 = arr[st], elem2 = arr[ed];
                while (st <= ed && arr[st] == elem1) {
                    cnt1++;
                    st++;
                }
                while (st <= ed && arr[ed] == elem2) {
                    cnt2++;
                    ed--;
                }
                if (elem1 == elem2)
                    count += (cnt1 * (cnt1 - 1)) / 2;
                count += (cnt1 * cnt2);
            }
        }
        return count;
    }
}