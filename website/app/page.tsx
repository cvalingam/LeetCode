import { getAllProblemsMeta } from '@/lib/problems'
import ProblemList from '@/components/ProblemList'

export default function HomePage({
  searchParams,
}: {
  searchParams: { q?: string }
}) {
  const problems = getAllProblemsMeta()
  const initialQuery = searchParams.q ?? ''

  return <ProblemList problems={problems} initialQuery={initialQuery} />
}
