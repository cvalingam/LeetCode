public class Solution
{
    public int TotalMoney(int n)
    {
        // Calculate the number of complete weeks and remaining days
        int completeWeeks = n / 7;
        int remainingDays = n % 7;

        // Calculate the sum for all complete weeks
        // First week sum: 28 (1+2+3+4+5+6+7)
        // Each subsequent week adds 7 more than the previous week
        // This forms an arithmetic sequence: 28, 35, 42, ...
        // Sum of arithmetic sequence: (first term + last term) * number of terms / 2
        int firstWeekSum = 28;
        int lastWeekSum = 28 + 7 * (completeWeeks - 1);
        int totalFromCompleteWeeks = (firstWeekSum + lastWeekSum) * completeWeeks / 2;

        // Calculate the sum for the remaining days
        // Starting amount for remaining days: completeWeeks + 1
        // The amounts form an arithmetic sequence starting from (completeWeeks + 1)
        // Sum = (first day + last day) * number of days / 2
        int firstDayOfRemainingWeek = completeWeeks + 1;
        int lastDayOfRemainingWeek = completeWeeks + remainingDays;
        int totalFromRemainingDays = (firstDayOfRemainingWeek + lastDayOfRemainingWeek) * remainingDays / 2;

        return totalFromCompleteWeeks + totalFromRemainingDays;
    }
}