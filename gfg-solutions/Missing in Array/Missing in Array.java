class Solution {

    // Note that the size of the array is n-1
    int missingNumber(int n, int arr[]) {
        int xorInd = 0;
        int xorVal = 0;
        for (int i = 1; i <= n; i++)
            xorInd ^= i;

        for (int val : arr)
            xorVal ^= val;

        return xorInd ^ xorVal;
    }
}

class Solution1 {
    int missingNum(int arr[]) {
        int n = arr.length;
        int xorInd = 0;
        for (int i = 0; i < n; i++)
            xorInd ^= arr[i];

        n = n + 1;
        if (n % 4 == 0)
            return xorInd ^ n;
        else if (n % 4 == 1)
            return xorInd ^ 1;
        else if (n % 4 == 2)
            return xorInd ^ (n + 1);
        else
            return xorInd;
    }
}