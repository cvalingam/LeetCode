class Solution {
    public int catchThieves(char[] arr, int k) {
        int ans = 0;
        int n = arr.length;
        
        for (int i = 0; i < n; i++) {
            if (arr[i] == 'P') {
                int l = Math.max(0, i - k);
                int u = Math.min(n - 1, i + k);
                for (int j = l; j <= u; j++) {
                    if (arr[j] == 'T') {
                        ans++;
                        arr[j] = 'S';
                        break;
                    }
                }
            }
        }

        return ans;
    }
}

//Version 2
class Solution1 {
    public int catchThieves(char[] arr, int k) {
        int n = arr.length;
        int i = 0, j = 0, count = 0;

        while (i < n && j < n) {
            while (i < n && arr[i] != 'P')
                i++;
            while (j < n && arr[j] != 'T')
                j++;
            if (i < n && j < n && Math.abs(i - j) <= k) {
                count++;
                i++;
                j++;
            } else if (j < n && j < i)
                j++;
            else if (i < n && i < j)
                i++;

        }
        return count;
    }
}