public class Solution
{
    public long MinTime(int[] skill, int[] mana)
    {
        long sumSkill = skill.Sum();
        long prevWizardDone = sumSkill * mana[0];

        for (int j = 1; j < mana.Length; ++j)
        {
            long prevPotionDone = prevWizardDone;
            for (int i = skill.Length - 2; i >= 0; --i)
            {
                prevPotionDone -= (long)skill[i + 1] * mana[j - 1];
                prevWizardDone = Math.Max(prevPotionDone, prevWizardDone - (long)skill[i] * mana[j]);
            }
            prevWizardDone += sumSkill * mana[j];
        }

        return prevWizardDone;
    }
}