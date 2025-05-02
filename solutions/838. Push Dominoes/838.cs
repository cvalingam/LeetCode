public class Solution
{
    public string PushDominoes(string dominoes)
    {
        int n = dominoes.Length;
        int[] forces = new int[n];

        // Left to Right: Apply 'R' forces
        int force = 0;
        for (int i = 0; i < n; i++)
        {
            if (dominoes[i] == 'R')
                force = n;  // Max possible force
            else if (dominoes[i] == 'L')
                force = 0;  // Reset on encountering 'L'
            else
                force = Math.Max(force - 1, 0);
            forces[i] += force;
        }

        // Right to Left: Apply 'L' forces
        force = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (dominoes[i] == 'L')
                force = n;  // Max possible force
            else if (dominoes[i] == 'R')
                force = 0;  // Reset on encountering 'R'
            else
                force = Math.Max(force - 1, 0);
            forces[i] -= force;
        }

        // Build final result based on net force
        char[] result = new char[n];
        for (int i = 0; i < n; i++)
        {
            if (forces[i] > 0)
                result[i] = 'R';
            else if (forces[i] < 0)
                result[i] = 'L';
            else
                result[i] = '.';
        }

        return new string(result);
    }
}