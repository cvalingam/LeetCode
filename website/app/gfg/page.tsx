import type { Metadata } from 'next'
import { Suspense } from 'react'
import { getAllGfgProblemsMeta } from '@/lib/gfg-problems'
import GfgProblemList from '@/components/GfgProblemList'
import gfgExplanations from '@/lib/gfg-explanations'

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
  const explanationSlugs = new Set(Object.keys(gfgExplanations))

  return (
    <>
      <Suspense fallback={<LoadingFallback />}>
        <GfgProblemList problems={problems} explanationSlugs={explanationSlugs} />
      </Suspense>
    </>
  )
}
