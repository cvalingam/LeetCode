using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    public string FractionAddition(string expression)
    {
        var ints = Regex.Matches(expression, @"[+-]?\d+")
                        .Cast<Match>()
                        .Select(m => int.Parse(m.Value))
                        .ToList();
        int A = 0;
        int B = 1;

        // Init: A / B = 0 / 1
        // A / B + a / b = (Ab + aB) / Bb
        // So, in each round, set A = Ab + aB, B = Bb.
        for (int i = 0; i < ints.Count; i += 2)
        {
            int a = ints[i];
            int b = ints[i + 1];
            A = A * b + a * B;
            B *= b;
            int g = Gcd(A, B);
            A /= g;
            B /= g;
        }

        return A + "/" + B;
    }

    private int Gcd(int a, int b)
    {
        return a == 0 ? Math.Abs(b) : Gcd(b % a, a);
    }
}