public class Solution
{
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        int arriveA = ToDays(arriveAlice);
        int leaveA = ToDays(leaveAlice);
        int arriveB = ToDays(arriveBob);
        int leaveB = ToDays(leaveBob);
        int ans = 0;

        for (int day = 1; day <= 365; ++day)
        {
            if (arriveA <= day && day <= leaveA && arriveB <= day && day <= leaveB)
                ++ans;
        }

        return ans;
    }

    private readonly int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    private int ToDays(string s)
    {
        int month = (s[0] - '0') * 10 + (s[1] - '0');
        int day = (s[3] - '0') * 10 + (s[4] - '0');
        int prevDays = 0;
        for (int m = 1; m < month; ++m)
            prevDays += days[m];

        return prevDays + day;
    }
}