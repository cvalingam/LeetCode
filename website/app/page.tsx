import { getAllProblemsMeta } from '@/lib/problems'
import ProblemList from '@/components/ProblemList'
import { Suspense } from 'react'

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
    <Suspense fallback={<LoadingFallback />}>
      <ProblemList problems={problems} />
    </Suspense>
  )
}
