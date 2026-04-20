import type { Metadata } from 'next'
import Link from 'next/link'
import { Suspense } from 'react'
import { getAllGfgProblemsMeta } from '@/lib/gfg-problems'
import GfgProblemList from '@/components/GfgProblemList'

export const dynamic = 'force-static'

export const metadata: Metadata = {
  title: 'GeeksforGeeks Java Solutions',
  description:
    'Clean Java solutions to GeeksforGeeks Problem of the Day — daily POTD solutions by Sivalingam Ramasamy.',
  keywords: ['GeeksforGeeks', 'GFG', 'Java', 'POTD', 'Problem of the Day', 'interview prep'],
  alternates: { canonical: '/gfg' },
  openGraph: {
    title: 'GeeksforGeeks Java Solutions — GFG POTD',
    description: 'Clean Java solutions to GeeksforGeeks Problem of the Day.',
    url: '/gfg',
    type: 'website',
  },
}

function LoadingFallback() {
  return (
    <div className="animate-pulse space-y-3 mt-8">
      {Array.from({ length: 10 }).map((_, i) => (
        <div key={i} className="h-10 bg-gray-100 rounded-lg" />
      ))}
    </div>
  )
}

export default function GfgPage() {
  const problems = getAllGfgProblemsMeta()

  return (
    <>
      {/* Hero intro */}
      <div className="mb-8">
        <h1 className="text-2xl sm:text-3xl font-bold text-gray-900 dark:text-gray-100 mb-3">
          GeeksforGeeks Java Solutions
        </h1>
        <p className="text-gray-600 dark:text-gray-400 text-sm sm:text-base leading-relaxed max-w-2xl mb-4">
          Clean Java solutions to {problems.length}+ GeeksforGeeks problems — covering GFG Problem of the Day
          (POTD) and frequently asked interview questions. Each solution includes a step-by-step explanation
          and complexity analysis to help you understand the approach, not just the answer.
        </p>
        <p className="text-gray-600 dark:text-gray-400 text-sm leading-relaxed max-w-2xl mb-4">
          GeeksforGeeks is the most widely used coding practice platform in India. Solving GFG POTD daily
          is an effective way to build consistency and cover a broad range of data structures and algorithms
          before a placement drive or off-campus interview.
        </p>
        <div className="flex flex-wrap gap-3 text-xs text-indigo-600 dark:text-indigo-400">
          <Link href="/" className="hover:underline">LeetCode C# Solutions →</Link>
          <Link href="/topics" className="hover:underline">Browse by Topic →</Link>
          <Link href="/study-guide" className="hover:underline">Study Guide →</Link>
        </div>
      </div>

      <Suspense fallback={<LoadingFallback />}>
        <GfgProblemList problems={problems} />
      </Suspense>
    </>
  )
}
