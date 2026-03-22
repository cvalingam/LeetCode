import type { Metadata } from 'next'
import { getAllProblemsMeta } from '@/lib/problems'
import ProblemList from '@/components/ProblemList'
import { Suspense } from 'react'
import { SITE_URL } from '@/lib/constants'

export const metadata: Metadata = {
  alternates: { canonical: '/' },
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
  return (
    <>
      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{ __html: JSON.stringify(websiteJsonLd) }}
      />
      <Suspense fallback={<LoadingFallback />}>
        <ProblemList problems={problems} />
      </Suspense>
    </>
  )
}
