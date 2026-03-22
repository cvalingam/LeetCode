import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllProblems, getProblemBySlug, getAdjacentProblems } from '@/lib/problems'
import { toLeetCodeSlug } from '@/lib/constants'
import CodeBlock from '@/components/CodeBlock'
import DifficultyBadge from '@/components/DifficultyBadge'
import AdUnit from '@/components/AdUnit'

interface Props {
  params: { slug: string }
}

// Tell Next.js which slugs to pre-render at build time
export async function generateStaticParams() {
  return getAllProblems().map(p => ({ slug: p.slug }))
}

// No dynamic pages at runtime — 404 for unknown slugs
export const dynamicParams = false

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const problem = getProblemBySlug(params.slug)
  if (!problem) return {}

  const title  = `${problem.number}. ${problem.title}`
  const desc   = `LeetCode ${problem.number} ${problem.title} — clean C# solution. ${problem.difficulty} difficulty.`
  const lcSlug = toLeetCodeSlug(problem.title)

  return {
    title,
    description: desc,
    alternates: {
      canonical: `/problems/${problem.slug}`,
    },
    openGraph: {
      title: `${title} — LeetCode C# Solution`,
      description: desc,
      type: 'article',
    },
    other: {
      // JSON-LD structured data for Google
      'application/ld+json': JSON.stringify({
        '@context': 'https://schema.org',
        '@type': 'TechArticle',
        headline: `${title} — LeetCode C# Solution`,
        description: desc,
        author: { '@type': 'Person', name: 'Sivalingam Ramasamy' },
        url: `https://leetcode.com/problems/${lcSlug}/`,
      }),
    },
  }
}

export default async function ProblemPage({ params }: Props) {
  const problem = getProblemBySlug(params.slug)
  if (!problem) notFound()

  const { prev, next } = getAdjacentProblems(params.slug)
  const lcSlug = toLeetCodeSlug(problem.title)

  return (
    <article className="max-w-3xl mx-auto py-8">
      {/* Ad: leaderboard */}
      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-8" />

      {/* Title */}
      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight mb-3">
        {problem.number}. {problem.title}
      </h1>

      {/* Meta row */}
      <div className="flex items-center gap-4 mb-8 flex-wrap">
        <DifficultyBadge difficulty={problem.difficulty} />
        <a
          href={`https://leetcode.com/problems/${lcSlug}/`}
          target="_blank"
          rel="nofollow noopener noreferrer"
          className="text-blue-600 hover:underline text-sm"
        >
          View on LeetCode ↗
        </a>
      </div>

      {/* Code */}
      <section className="mb-8">
        <h2 className="text-lg font-semibold mb-3">C# Solution</h2>
        <CodeBlock code={problem.code} />
      </section>

      {/* Ad: rectangle */}
      <AdUnit slot="YOUR_AD_SLOT" style="rectangle" className="mb-8" />

      {/* Prev / Next navigation */}
      <nav className="flex justify-between items-center border-t border-slate-200 pt-6 gap-3 flex-wrap">
        {prev ? (
          <Link
            href={`/problems/${prev.slug}`}
            className="flex items-center gap-2 px-4 py-2 border border-slate-200 rounded-lg text-sm text-slate-700 hover:border-blue-400 hover:text-blue-600 transition-colors max-w-[46%] truncate"
          >
            ← {prev.number}. {prev.title}
          </Link>
        ) : (
          <span />
        )}

        <Link
          href="/"
          className="px-4 py-2 border border-slate-200 rounded-lg text-sm text-slate-500 hover:border-blue-400 hover:text-blue-600 transition-colors"
        >
          ☰ All Problems
        </Link>

        {next ? (
          <Link
            href={`/problems/${next.slug}`}
            className="flex items-center gap-2 px-4 py-2 border border-slate-200 rounded-lg text-sm text-slate-700 hover:border-blue-400 hover:text-blue-600 transition-colors max-w-[46%] truncate"
          >
            {next.number}. {next.title} →
          </Link>
        ) : (
          <span />
        )}
      </nav>
    </article>
  )
}
