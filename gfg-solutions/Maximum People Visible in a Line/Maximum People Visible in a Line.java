import java.util.*;

class Solution {
    public int maxPeople(int[] arr) {
        int n = arr.length;
        int[] nextGreaterOrEqualHeightedPerson = new int[n];
        int[] previousGreaterOrEqualHeightedPerson = new int[n];

        int maxPeopleSeeByAPerson = Integer.MIN_VALUE;
        NGEE(arr, nextGreaterOrEqualHeightedPerson);
        PGEE(arr, previousGreaterOrEqualHeightedPerson);

        for (int i = 0; i < n; i++) {
            int person_i_can_see = nextGreaterOrEqualHeightedPerson[i]
                    - previousGreaterOrEqualHeightedPerson[i] - 1;
            maxPeopleSeeByAPerson = Math.max(maxPeopleSeeByAPerson, person_i_can_see);
        }
        return maxPeopleSeeByAPerson;
    }

    // find next greater or equal heighted person
    public void NGEE(int[] arr, int[] nextGreaterOrEqualHeightedPerson) {
        int n = arr.length;
        int j = n - 1;
        Stack<Integer> stack = new Stack<>();

        while (j >= 0) {
            while (!stack.isEmpty() && arr[stack.peek()] < arr[j])
                stack.pop();

            if (stack.isEmpty())
                nextGreaterOrEqualHeightedPerson[j] = n;
            else
                nextGreaterOrEqualHeightedPerson[j] = stack.peek();

            stack.push(j);
            j--;
        }
    }

    // find previous greater or equal heighted person
    public void PGEE(int[] arr, int[] previousGreaterOrEqualHeightedPerson) {
        int n = arr.length;
        int j = 0;
        Stack<Integer> stack = new Stack<>();

        while (j < n) {
            while (!stack.isEmpty() && arr[stack.peek()] < arr[j])
                stack.pop();

            if (stack.isEmpty())
                previousGreaterOrEqualHeightedPerson[j] = -1;
            else
                previousGreaterOrEqualHeightedPerson[j] = stack.peek();

            stack.push(j);
            j++;
        }
    }
}
