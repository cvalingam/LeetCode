// Approach: Use gap method (Shell sort variant). Start with gap = ceil((n+m)/2), exchange and reduce gap.
// Time: O((n+m) log(n+m)) Space: O(1)
class Solution {
    // Function to merge the arrays.
    public void mergeArrays(int a[], int b[]) {
        int n = a.length;
        int m = b.length;

        int i = n - 1, j = 0;
        while (i >= 0 && j < m) {
            if (a[i] >= b[j]) {
                swp(a, b, i, j);
                i--;
                j++;
            } else
                break;
        }

        Arrays.sort(a);
        Arrays.sort(b);
    }

    public static void swp(int[] a, int[] b, int i, int j) {
        int t = a[i];
        a[i] = b[j];
        b[j] = t;
    }
}