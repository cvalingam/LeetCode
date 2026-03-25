// Approach: Sort sides; check triangle validity then classify equilateral/isosceles/scalene.
// Time: O(1) Space: O(1)

public class Solution
{
    public string TriangleType(int[] nums)
    {
        Array.Sort(nums);
        if (nums[0] + nums[1] <= nums[2])
            return "none";
        if (nums[0] == nums[1] && nums[1] == nums[2])
            return "equilateral";
        if (nums[0] == nums[1] || nums[1] == nums[2])
            return "isosceles";
        return "scalene";
    }
}