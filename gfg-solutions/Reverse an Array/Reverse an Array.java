class Solution {
    public void reverseArray(int arr[]) {
        int i = 0, j = arr.length - 1;
        while (i <= j) {
            int c = arr[i];
            arr[i] = arr[j];
            arr[j] = c;

            i++;
            j--;
        }
    }
}