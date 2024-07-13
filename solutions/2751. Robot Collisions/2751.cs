public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var ans = new List<int>();
        var robots = new Robot[positions.Length];
        var stack = new List<Robot>();

        for (int i = 0; i < positions.Length; ++i)
            robots[i] = new Robot(i, positions[i], healths[i], directions[i]);

        Array.Sort(robots, (a, b) => a.position - b.position);

        foreach (Robot robot in robots)
        {
            if (robot.direction == 'R')
            {
                stack.Add(robot);
                continue;
            }

            while (stack.Count > 0 && stack[stack.Count - 1].direction == 'R' && robot.health > 0)
            {
                if (stack[stack.Count - 1].health == robot.health)
                {
                    stack.RemoveAt(stack.Count - 1);
                    robot.health = 0;
                }
                else if (stack[stack.Count - 1].health < robot.health)
                {
                    stack.RemoveAt(stack.Count - 1);
                    robot.health -= 1;
                }
                else
                {
                    stack[stack.Count - 1].health -= 1;
                    robot.health = 0;
                }
            }
            if (robot.health > 0)
                stack.Add(robot);
        }

        stack.Sort((a, b) => a.index - b.index);

        foreach (Robot robot in stack)
            ans.Add(robot.health);

        return ans;
    }
}

class Robot
{
    public int index;
    public int position;
    public int health;
    public char direction;
    public Robot(int index, int position, int health, char direction)
    {
        this.index = index;
        this.position = position;
        this.health = health;
        this.direction = direction;
    }
}