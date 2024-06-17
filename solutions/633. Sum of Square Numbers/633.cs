public class Solution {
    public bool JudgeSquareSum(int c) {
        long l = 0;
        long r = (long)Math.Sqrt(c);

        while(l <= r)
        {
            long sum = (l * l) + (r * r);
            if(sum == c)
                return true;
            else if(sum < c)
                l++;
            else
                r--;
        }

        return false;
    }
}