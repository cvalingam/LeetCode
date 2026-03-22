import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllGfgProblems, getGfgProblemBySlug, getAdjacentGfgProblems } from '@/lib/gfg-problems'
import { toLeetCodeSlug, SITE_URL } from '@/lib/constants'
import CodeBlockWithHeader from '@/components/CodeBlockWithHeader'
import AdUnit from '@/components/AdUnit'

interface Props {
  params: { slug: string }
}

export async function generateStaticParams() {
  return getAllGfgProblems().map(p => ({ slug: p.slug }))
}

export const dynamicParams = false

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const problem = getGfgProblemBySlug(params.slug)
  if (!problem) return {}

  const title = problem.title
  const desc  = `GeeksforGeeks: ${problem.title} — clean Java solution. GFG Problem of the Day.`

  return {
    title,
    description: desc,
    alternates: { canonical: `/gfg/${problem.slug}` },
    openGraph: {
      title: `${title} — GFG Java Solution`,
      description: desc,
      type: 'article',
    },
    other: {
      'application/ld+json': JSON.stringify({
        '@context': 'https://schema.org',
        '@type': 'TechArticle',
        headline: `${title} — GFG Java Solution`,
        description: desc,
        author: { '@type': 'Person', name: 'Sivalingam Ramasamy', url: 'https://github.com/cvalingam' },
        url: `${SITE_URL}/gfg/${problem.slug}`,
      }),
    },
  }
}

export default async function GfgProblemPage({ params }: Props) {
  const problem = getGfgProblemBySlug(params.slug)
  if (!problem) notFound()

  const { prev, next } = getAdjacentGfgProblems(params.slug)
  const gfgSlug = toLeetCodeSlug(problem.title)

  return (
    <article className="max-w-3xl mx-auto py-8">

      {/* Breadcrumb */}
      <nav className="flex items-center gap-1.5 text-xs text-gray-400 mb-6" aria-label="Breadcrumb">
        <Link href="/gfg" className="hover:text-emerald-600 transition-colors">GFG</Link>
        <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
        <span className="text-gray-600 font-medium truncate">{problem.title}</span>
      </nav>

      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-8" />

      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight text-gray-900 mb-3">
        {problem.title}
      </h1>

      <div className="flex items-center gap-3 mb-8 flex-wrap">
        <span className="inline-flex items-center gap-1.5 px-2.5 py-0.5 rounded-full text-xs font-medium text-orange-700 bg-orange-50">
          <span className="w-1.5 h-1.5 rounded-full bg-orange-500" />
          Java
        </span>
        <span className="w-px h-4 bg-gray-200" />
        <a
          href={`https://www.geeksforgeeks.org/problems/${gfgSlug}/1`}
          target="_blank"
          rel="nofollow noopener noreferrer"
          className="inline-flex items-center gap-1 text-sm text-emerald-600 hover:text-emerald-800 transition-colors"
        >
          View on GFG
          <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
            <path strokeLinecap="round" strokeLinejoin="round" d="M10 6H6a2 2 0 00-2 2v10a2 2 0 002 2h10a2 2 0 002-2v-4M14 4h6m0 0v6m0-6L10 14" />
          </svg>
        </a>
      </div>

      <section className="mb-8">
        <CodeBlockWithHeader
          code={problem.code}
          lang="java"
          filename={`${problem.title}.java`}
        />
      </section>

      <AdUnit slot="YOUR_AD_SLOT" style="rectangle" className="mb-8" />

      <nav className="flex justify-between items-center border-t border-gray-100 pt-6 gap-3 flex-wrap" aria-label="Problem navigation">
        {prev ? (
          <Link
            href={`/gfg/${prev.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white border border-gray-200 rounded-xl text-sm text-gray-700 hover:border-emerald-300 hover:bg-emerald-50/50 hover:text-emerald-700 transition-all shadow-sm max-w-[46%]"
          >
            <svg className="w-4 h-4 shrink-0 text-gray-400 group-hover:text-emerald-500 transition-colors" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <path strokeLinecap="round" strokeLinejoin="round" d="M15 19l-7-7 7-7" />
            </svg>
            <span className="truncate">{prev.title}</span>
          </Link>
        ) : (
          <span />
        )}

        <Link
          href="/gfg"
          className="px-4 py-2.5 bg-white border border-gray-200 rounded-xl text-sm text-gray-500 hover:border-emerald-300 hover:text-emerald-600 transition-all shadow-sm hidden sm:block"
        >
          All GFG Problems
        </Link>

        {next ? (
          <Link
            href={`/gfg/${next.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white border border-gray-200 rounded-xl text-sm text-gray-700 hover:border-emerald-300 hover:bg-emerald-50/50 hover:text-emerald-700 transition-all shadow-sm max-w-[46%]"
          >
            <span className="truncate">{next.title}</span>
            <svg className="w-4 h-4 shrink-0 text-gray-400 group-hover:text-emerald-500 transition-colors" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
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
