import { getAllProblemsMeta } from '@/lib/problems'
import ProblemList from '@/components/ProblemList'
import { Suspense } from 'react'

export default function HomePage() {
  const problems = getAllProblemsMeta()
  return (
    <Suspense>
      <ProblemList problems={problems} />
    </Suspense>
  )
}
