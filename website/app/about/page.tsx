import type { Metadata } from 'next'
import Link from 'next/link'

export const metadata: Metadata = {
  title: 'About',
  description: 'About the LeetCode C# Solutions website — clean, readable C# code for .NET interview prep.',
}

export default function AboutPage() {
  return (
    <div className="max-w-2xl mx-auto py-10 prose prose-slate">
      <h1 className="text-3xl font-bold mb-2">About</h1>
      <p className="text-slate-500 mb-8">This site provides clean, well-structured C# solutions to LeetCode problems.</p>

      <h2 className="text-xl font-semibold mt-8 mb-3">Why C#?</h2>
      <p className="text-slate-600">
        Most LeetCode solution repositories focus on C++, Java, or Python. High-quality, consistent C# solutions
        are hard to find. This site fills that gap with idiomatic .NET code that mirrors real interview expectations
        for .NET developers.
      </p>

      <h2 className="text-xl font-semibold mt-8 mb-3">What you will find here</h2>
      <ul className="list-disc pl-5 text-slate-600 space-y-1">
        <li>Clean, readable C# code with consistent naming conventions</li>
        <li>800+ solutions covering Easy, Medium, and Hard difficulty levels</li>
        <li>Full coverage of arrays, trees, graphs, dynamic programming, and more</li>
        <li>Fast search and difficulty filtering to find any problem instantly</li>
        <li>Syntax-highlighted code with zero JavaScript overhead on page load</li>
      </ul>

      <h2 className="text-xl font-semibold mt-8 mb-3">About the author</h2>
      <p className="text-slate-600">
        Sivalingam Ramasamy is a software developer based in Chennai, India, passionate about
        algorithms and clean code. He solves LeetCode problems daily and documents solutions here
        to help the .NET community prepare for technical interviews.
      </p>

      <h2 className="text-xl font-semibold mt-8 mb-3">Source code</h2>
      <p className="text-slate-600">
        All solutions are open-source under the MIT License and available on{' '}
        <a
          href="https://github.com/cvalingam/LeetCode"
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
