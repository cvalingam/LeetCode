import type { Metadata } from 'next'
import { getAllGfgProblemsMeta } from '@/lib/gfg-problems'
import GfgProblemList from '@/components/GfgProblemList'

// Force static rendering at build time — gfg-solutions/ is only present during
// the Vercel build (cloned by vercel.json buildCommand), not at runtime.
export const dynamic = 'force-static'

export const metadata: Metadata = {
  title: 'GeeksforGeeks Java Solutions',
  description:
    'Clean Java solutions to GeeksforGeeks Problem of the Day — daily POTD solutions by Sivalingam Ramasamy.',
}

export default function GfgPage({
  searchParams,
}: {
  searchParams: { q?: string }
}) {
  const problems = getAllGfgProblemsMeta()
  const initialQuery = searchParams.q ?? ''
  return <GfgProblemList problems={problems} initialQuery={initialQuery} />
}
