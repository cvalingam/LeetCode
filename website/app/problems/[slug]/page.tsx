import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllProblems, getProblemBySlug, getAdjacentProblems } from '@/lib/problems'
import { toLeetCodeSlug } from '@/lib/constants'
import CodeBlockWithHeader from '@/components/CodeBlockWithHeader'
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
        author: { '@type': 'Person', name: 'Sivalingam Ramasamy', url: 'https://github.com/cvalingam' },
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

      {/* Breadcrumb */}
      <nav className="flex items-center gap-1.5 text-xs text-gray-400 mb-6" aria-label="Breadcrumb">
        <Link href="/" className="hover:text-indigo-600 transition-colors">LeetCode</Link>
        <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
        <span className="text-gray-600 font-medium truncate">{problem.number}. {problem.title}</span>
      </nav>

      {/* Ad: leaderboard */}
      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-8" />

      {/* Title */}
      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight text-gray-900 mb-3">
        {problem.number}. {problem.title}
      </h1>

      {/* Meta row */}
      <div className="flex items-center gap-3 mb-8 flex-wrap">
        <DifficultyBadge difficulty={problem.difficulty} />
        <span className="w-px h-4 bg-gray-200" />
        <a
          href={`https://leetcode.com/problems/${lcSlug}/`}
          target="_blank"
          rel="nofollow noopener noreferrer"
          className="inline-flex items-center gap-1 text-sm text-indigo-600 hover:text-indigo-800 transition-colors"
        >
          View on LeetCode
          <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
            <path strokeLinecap="round" strokeLinejoin="round" d="M10 6H6a2 2 0 00-2 2v10a2 2 0 002 2h10a2 2 0 002-2v-4M14 4h6m0 0v6m0-6L10 14" />
          </svg>
        </a>
      </div>

      {/* Code */}
      <section className="mb-8">
        <CodeBlockWithHeader
          code={problem.code}
          lang="csharp"
          filename={`${problem.number}.cs`}
        />
      </section>

      {/* Ad: rectangle */}
      <AdUnit slot="YOUR_AD_SLOT" style="rectangle" className="mb-8" />

      {/* Prev / Next navigation */}
      <nav className="flex justify-between items-center border-t border-gray-100 pt-6 gap-3 flex-wrap" aria-label="Problem navigation">
        {prev ? (
          <Link
            href={`/problems/${prev.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white border border-gray-200 rounded-xl text-sm text-gray-700 hover:border-indigo-300 hover:bg-indigo-50/50 hover:text-indigo-700 transition-all shadow-sm max-w-[46%]"
          >
            <svg className="w-4 h-4 shrink-0 text-gray-400 group-hover:text-indigo-500 transition-colors" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <path strokeLinecap="round" strokeLinejoin="round" d="M15 19l-7-7 7-7" />
            </svg>
            <span className="truncate">{prev.number}. {prev.title}</span>
          </Link>
        ) : (
          <span />
        )}

        <Link
          href="/"
          className="px-4 py-2.5 bg-white border border-gray-200 rounded-xl text-sm text-gray-500 hover:border-indigo-300 hover:text-indigo-600 transition-all shadow-sm hidden sm:block"
        >
          All Problems
        </Link>

        {next ? (
          <Link
            href={`/problems/${next.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white border border-gray-200 rounded-xl text-sm text-gray-700 hover:border-indigo-300 hover:bg-indigo-50/50 hover:text-indigo-700 transition-all shadow-sm max-w-[46%]"
          >
            <span className="truncate">{next.number}. {next.title}</span>
            <svg className="w-4 h-4 shrink-0 text-gray-400 group-hover:text-indigo-500 transition-colors" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
            </svg>
          </Link>
        ) : (
          <span />
        )}
      </nav>
    </article>
  )
}
