// Approach: Parse age from chars at index 11-12 of each detail string; count those > 60.
// Time: O(n) Space: O(1)

public class Solution
{
    public int CountSeniors(string[] details)
    {
        // foreach(string d in details)
        //     Console.WriteLine(d.Substring(11, 2));

        return details.Where(x => Int32.Parse(x.Substring(11, 2)) > 60).Count();
    }
}