import java.util.*;

class Solution {
    static int maxArea(int mat[][]) {
        int h[] = new int[mat[0].length];

        int pse[] = new int[mat[0].length];
        int nse[] = new int[pse.length];

        int ans = 0;

        for (var a : mat) {
            for (int i = 0; i < h.length; i++)
                h[i] = a[i] == 1 ? h[i] + 1 : 0;

            PSE(h, pse);
            NSE(h, nse);

            for (int i = 0; i < h.length; i++) {
                if (h[i] == 0)
                    continue;
                ans = Math.max(ans, (nse[i] - pse[i] - 1) * h[i]);
            }
        }

        return ans;
    }

    static void PSE(int arr[], int pse[]) {
        Stack<Integer> st = new Stack<>();
        for (int i = 0; i < arr.length; i++) {
            while (st.size() > 0 && arr[st.peek()] >= arr[i])
                st.pop();
            if (st.size() == 0)
                pse[i] = -1;
            else
                pse[i] = st.peek();
            st.push(i);
        }
    }

    static void NSE(int arr[], int nse[]) {
        Stack<Integer> st = new Stack<>();
        for (int i = arr.length - 1; i >= 0; i--) {
            while (st.size() > 0 && arr[st.peek()] >= arr[i])
                st.pop();
            if (st.size() == 0)
                nse[i] = arr.length;
            else
                nse[i] = st.peek();
            st.push(i);
        }
    }
}