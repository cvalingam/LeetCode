import type { Metadata } from 'next'
import { getAllProblemsMeta } from '@/lib/problems'
import ProblemList from '@/components/ProblemList'
import { Suspense } from 'react'
import { SITE_URL } from '@/lib/constants'
import explanations from '@/lib/explanations'

export const metadata: Metadata = {
  title: 'LeetCode C# Solutions — 800+ Problems Solved',
  description: 'Clean, readable C# solutions to 800+ LeetCode problems and 550+ GeeksforGeeks Java solutions. Built for .NET developers cracking the coding interview.',
  alternates: { canonical: '/' },
  openGraph: {
    title: 'LeetCode C# Solutions — DSA Solutions',
    description: 'Clean, readable C# solutions to 800+ LeetCode problems and 550+ GeeksforGeeks Java solutions.',
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
  const explanationNums = new Set(Object.keys(explanations).map(Number))

  return (
    <>
      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{ __html: JSON.stringify(websiteJsonLd) }}
      />

      <Suspense fallback={<LoadingFallback />}>
        <ProblemList problems={problems} explanationNums={explanationNums} />
      </Suspense>
    </>
  )
}
