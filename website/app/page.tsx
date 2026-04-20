import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllProblemsMeta } from '@/lib/problems'
import ProblemList from '@/components/ProblemList'
import { Suspense } from 'react'
import { SITE_URL } from '@/lib/constants'

export const metadata: Metadata = {
  title: 'LeetCode C# Solutions — 800+ Problems Solved',
  description: 'Clean, readable C# solutions to 800+ LeetCode problems and 500+ GeeksforGeeks Java solutions. Built for .NET developers cracking the coding interview.',
  alternates: { canonical: '/' },
  openGraph: {
    title: 'LeetCode C# Solutions — DSA Solutions',
    description: 'Clean, readable C# solutions to 800+ LeetCode problems and 500+ GeeksforGeeks Java solutions.',
    url: '/',
    type: 'website',
  },
}

const websiteJsonLd = {
  '@context': 'https://schema.org',
  '@type': 'WebSite',
  name: 'DSA Solutions',
  url: SITE_URL,
  potentialAction: {
    '@type': 'SearchAction',
    target: `${SITE_URL}/?q={search_term_string}`,
    'query-input': 'required name=search_term_string',
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

export default function HomePage() {
  const problems = getAllProblemsMeta()
  const easyCount = problems.filter(p => p.difficulty === 'Easy').length
  const mediumCount = problems.filter(p => p.difficulty === 'Medium').length
  const hardCount = problems.filter(p => p.difficulty === 'Hard').length

  return (
    <>
      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{ __html: JSON.stringify(websiteJsonLd) }}
      />

      {/* Hero intro */}
      <div className="mb-8">
        <h1 className="text-2xl sm:text-3xl font-bold text-gray-900 dark:text-gray-100 mb-3">
          LeetCode C# Solutions
        </h1>
        <p className="text-gray-600 dark:text-gray-400 text-sm sm:text-base leading-relaxed max-w-2xl mb-4">
          Clean, well-commented C# solutions to {problems.length}+ LeetCode problems — written for .NET developers
          preparing for coding interviews. Every solution includes a plain-English explanation and time/space
          complexity analysis so you understand <em>why</em> it works, not just that it does.
        </p>
        {/* Stat chips */}
        <div className="flex flex-wrap gap-2 mb-4">
          <span className="inline-flex items-center gap-1.5 px-3 py-1 rounded-full bg-emerald-50 dark:bg-emerald-950/30 text-emerald-700 dark:text-emerald-400 text-xs font-medium">
            <span className="w-1.5 h-1.5 rounded-full bg-emerald-500 inline-block" />
            {easyCount} Easy
          </span>
          <span className="inline-flex items-center gap-1.5 px-3 py-1 rounded-full bg-amber-50 dark:bg-amber-950/30 text-amber-700 dark:text-amber-400 text-xs font-medium">
            <span className="w-1.5 h-1.5 rounded-full bg-amber-500 inline-block" />
            {mediumCount} Medium
          </span>
          <span className="inline-flex items-center gap-1.5 px-3 py-1 rounded-full bg-red-50 dark:bg-red-950/30 text-red-700 dark:text-red-400 text-xs font-medium">
            <span className="w-1.5 h-1.5 rounded-full bg-red-500 inline-block" />
            {hardCount} Hard
          </span>
        </div>
        <div className="flex flex-wrap gap-3 text-xs text-indigo-600 dark:text-indigo-400">
          <Link href="/study-guide" className="hover:underline">Study Guide →</Link>
          <Link href="/cheat-sheet" className="hover:underline">C# Cheat Sheet →</Link>
          <Link href="/topics" className="hover:underline">Browse by Topic →</Link>
          <Link href="/gfg" className="hover:underline">GFG Java Solutions →</Link>
        </div>
      </div>

      <Suspense fallback={<LoadingFallback />}>
        <ProblemList problems={problems} />
      </Suspense>
    </>
  )
}
