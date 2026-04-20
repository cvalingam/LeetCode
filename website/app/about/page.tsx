import type { Metadata } from 'next'
import Link from 'next/link'

export const metadata: Metadata = {
  title: 'About DSA Solutions',
  description: 'About DSA Solutions — clean C# LeetCode and Java GFG solutions with explanations for .NET developers preparing for coding interviews.',
  alternates: { canonical: '/about' },
  keywords: ['LeetCode', 'GeeksforGeeks', 'C#', 'Java', 'DSA', 'interview prep'],
  openGraph: {
    title: 'About DSA Solutions',
    description: 'About DSA Solutions — clean C# LeetCode and Java GFG solutions with explanations for .NET developers preparing for coding interviews.',
    url: '/about',
    type: 'website',
  },
}

export default function AboutPage() {
  return (
    <div className="max-w-2xl mx-auto py-10">
      <h1 className="text-3xl font-bold mb-2 text-gray-900 dark:text-gray-100">About DSA Solutions</h1>
      <p className="text-slate-500 dark:text-slate-400 mb-10">
        A daily-updated reference for LeetCode C# solutions and GeeksforGeeks Java solutions,
        built specifically for developers in the .NET ecosystem preparing for technical interviews.
      </p>

      <section className="mb-8">
        <h2 className="text-xl font-semibold mb-3 text-gray-900 dark:text-gray-100">Why this site exists</h2>
        <p className="text-slate-600 dark:text-slate-300 leading-relaxed mb-3">
          When I started preparing for interviews, I noticed that virtually every LeetCode solution repository
          on GitHub focuses on C++, Python, or Java. C# — the primary language for millions of .NET
          developers — was an afterthought. Solutions written in C# were either scarce, inconsistently
          formatted, or missing altogether for newer problems.
        </p>
        <p className="text-slate-600 dark:text-slate-300 leading-relaxed">
          DSA Solutions was built to fill that gap. Every solution is written in idiomatic C# using
          modern .NET APIs — <code className="bg-gray-100 dark:bg-gray-800 px-1 rounded text-sm">PriorityQueue</code>,{' '}
          <code className="bg-gray-100 dark:bg-gray-800 px-1 rounded text-sm">SortedSet</code>,{' '}
          <code className="bg-gray-100 dark:bg-gray-800 px-1 rounded text-sm">Dictionary</code>, pattern
          matching — the same way a .NET developer would write production code.
        </p>
      </section>

      <section className="mb-8">
        <h2 className="text-xl font-semibold mb-3 text-gray-900 dark:text-gray-100">How solutions are written</h2>
        <p className="text-slate-600 dark:text-slate-300 leading-relaxed mb-3">
          Each solution follows a consistent structure designed to make it useful as a study reference,
          not just a code answer:
        </p>
        <ul className="list-disc pl-5 text-slate-600 dark:text-slate-300 space-y-2 leading-relaxed">
          <li>
            <strong className="text-gray-800 dark:text-gray-200">Explanation first.</strong> Every page
            shows a plain-English explanation of the approach — why the algorithm works, what data
            structure is used, and how to recognise when to apply this pattern.
          </li>
          <li>
            <strong className="text-gray-800 dark:text-gray-200">Complexity stated explicitly.</strong> Time
            and Space complexity are shown as badges on every solution page, with a brief reasoning for
            why those complexities hold.
          </li>
          <li>
            <strong className="text-gray-800 dark:text-gray-200">Idiomatic C# code.</strong> Solutions use
            the most readable C# idiom available — not the shortest possible code, not a Java
            translation. The goal is code that a .NET engineer would write and be comfortable reviewing.
          </li>
          <li>
            <strong className="text-gray-800 dark:text-gray-200">Daily updates.</strong> New solutions for
            LeetCode and GeeksforGeeks POTD are added every day, ensuring the site stays current with
            the latest contest problems.
          </li>
        </ul>
      </section>

      <section className="mb-8">
        <h2 className="text-xl font-semibold mb-3 text-gray-900 dark:text-gray-100">What you will find here</h2>
        <ul className="list-disc pl-5 text-slate-600 dark:text-slate-300 space-y-1 leading-relaxed">
          <li>800+ clean C# LeetCode solutions covering Easy, Medium, and Hard difficulty</li>
          <li>530+ Java GeeksforGeeks POTD solutions, updated daily</li>
          <li>Topic pages for 60+ DSA patterns (Array, DP, Trees, Graphs, and more)</li>
          <li>Difficulty filtering and instant search to find any problem in seconds</li>
          <li>Syntax-highlighted code with one-click copy on every page</li>
          <li>A <Link href="/study-guide" className="text-blue-600 hover:underline">full study guide</Link> covering the 30-day plan, C# tips, and interview strategy</li>
        </ul>
      </section>

      <section className="mb-8">
        <h2 className="text-xl font-semibold mb-3 text-gray-900 dark:text-gray-100">Why Java for GFG?</h2>
        <p className="text-slate-600 dark:text-slate-300 leading-relaxed">
          GeeksforGeeks Problem of the Day is one of the most popular daily coding challenges in India,
          with a strong community of students and early-career developers. Solutions here are in Java —
          the most widely expected language for GFG submissions — and include the same explanation +
          complexity format as the LeetCode C# solutions.
        </p>
      </section>

      <section className="mb-8">
        <h2 className="text-xl font-semibold mb-3 text-gray-900 dark:text-gray-100">About the author</h2>
        <p className="text-slate-600 dark:text-slate-300 leading-relaxed mb-3">
          Sivalingam Ramasamy is a software developer based in Chennai, India, with experience in
          .NET, C#, and full-stack development. He began solving LeetCode problems daily to sharpen
          his algorithmic thinking and started this site to share clean solutions with the broader
          .NET community.
        </p>
        <p className="text-slate-600 dark:text-slate-300 leading-relaxed">
          The project is open-source under the MIT License and available on{' '}
          <a
            href="https://github.com/cvalingam/DSA-Solutions"
            target="_blank"
            rel="noopener noreferrer"
            className="text-blue-600 hover:underline"
          >
            GitHub
          </a>. Contributions, corrections, and alternative solutions are welcome via pull request.
        </p>
      </section>

      <div className="mt-10 flex gap-3 flex-wrap">
        <Link href="/" className="text-blue-600 hover:underline text-sm">← LeetCode Solutions</Link>
        <span className="text-gray-300 dark:text-gray-700">|</span>
        <Link href="/study-guide" className="text-blue-600 hover:underline text-sm">Study Guide →</Link>
      </div>
    </div>
  )
}
