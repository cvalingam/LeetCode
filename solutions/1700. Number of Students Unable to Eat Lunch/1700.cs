public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        int[] count = new int[2];

        foreach (int student in students)
            ++count[student];

        for (int i = 0; i < sandwiches.Length; ++i)
        {
            if (count[sandwiches[i]] == 0)
                return sandwiches.Length - i;
            --count[sandwiches[i]];
        }

        return 0;
    }
}