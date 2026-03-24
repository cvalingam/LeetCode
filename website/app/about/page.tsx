import type { Metadata } from 'next'
import Link from 'next/link'

export const metadata: Metadata = {
  title: 'About DSA Solutions',
  description: 'About DSA Solutions — clean C# LeetCode and Java GFG solutions for interview prep.',
  alternates: { canonical: '/about' },
  keywords: ['LeetCode', 'GeeksforGeeks', 'C#', 'Java', 'DSA', 'interview prep'],
}

export default function AboutPage() {
  return (
    <div className="max-w-2xl mx-auto py-10 prose prose-slate dark:prose-invert">
      <h1 className="text-3xl font-bold mb-2">About</h1>
      <p className="text-slate-500 dark:text-slate-400 mb-8">This site provides clean, well-structured C# solutions to LeetCode problems and Java solutions to GeeksforGeeks POTD.</p>

      <h2 className="text-xl font-semibold mt-8 mb-3">Why C#?</h2>
      <p className="text-slate-600 dark:text-slate-300">
        Most LeetCode solution repositories focus on C++, Java, or Python. High-quality, consistent C# solutions
        are hard to find. This site fills that gap with idiomatic .NET code that mirrors real interview expectations
        for .NET developers.
      </p>

      <h2 className="text-xl font-semibold mt-8 mb-3">Why Java for GFG?</h2>
      <p className="text-slate-600 dark:text-slate-300">
        GeeksforGeeks Problem of the Day is one of the most popular daily coding challenges in India.
        Solutions here are in Java — the most widely expected language for GFG submissions — updated daily.
      </p>

      <h2 className="text-xl font-semibold mt-8 mb-3">What you will find here</h2>
      <ul className="list-disc pl-5 text-slate-600 dark:text-slate-300 space-y-1">
        <li>800+ clean C# LeetCode solutions covering Easy, Medium, and Hard difficulty</li>
        <li>500+ Java GeeksforGeeks POTD solutions, updated daily</li>
        <li>Full coverage of arrays, trees, graphs, dynamic programming, and more</li>
        <li>Fast search and difficulty filtering to find any problem instantly</li>
        <li>Syntax-highlighted code with one-click copy on every page</li>
      </ul>

      <h2 className="text-xl font-semibold mt-8 mb-3">About the author</h2>
      <p className="text-slate-600 dark:text-slate-300">
        Sivalingam Ramasamy is a software developer based in Chennai, India, passionate about
        algorithms and clean code. He solves LeetCode problems daily and documents solutions here
        to help the .NET community prepare for technical interviews.
      </p>

      <h2 className="text-xl font-semibold mt-8 mb-3">Source code</h2>
      <p className="text-slate-600 dark:text-slate-300">
        All solutions are open-source under the MIT License and available on{' '}
        <a
          href="https://github.com/cvalingam/DSA-Solutions"
          target="_blank"
          rel="noopener noreferrer"
          className="text-blue-600 hover:underline"
        >
          GitHub
        </a>.
      </p>

      <div className="mt-10">
        <Link href="/" className="text-blue-600 hover:underline text-sm">← Back to all problems</Link>
      </div>
    </div>
  )
}
