class Solution {
    public boolean canServe(int[] arr) {
        if (arr[0] != 5)
            return false;
        int num[] = new int[21];
        for (int i = 0; i < arr.length; i++) {
            num[arr[i]]++;
            if (arr[i] == 10) {
                if (num[5] > 0)
                    num[5]--;
                else
                    return false;
            } else if (arr[i] == 20) {
                if (num[5] > 0 && num[10] > 0) {
                    num[5]--;
                    num[10]--;
                } else if (num[5] > 2)
                    num[5] = num[5] - 3;
                else
                    return false;
            }
        }
        return true;
    }
}