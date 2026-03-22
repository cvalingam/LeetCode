import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllGfgProblems, getGfgProblemBySlug, getAdjacentGfgProblems } from '@/lib/gfg-problems'
import CodeBlock from '@/components/CodeBlock'
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
      }),
    },
  }
}

export default async function GfgProblemPage({ params }: Props) {
  const problem = getGfgProblemBySlug(params.slug)
  if (!problem) notFound()

  const { prev, next } = getAdjacentGfgProblems(params.slug)
  const gfgSearchSlug = problem.title.replace(/\s+/g, '+')

  return (
    <article className="max-w-3xl mx-auto py-8">
      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-8" />

      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight mb-3">
        {problem.title}
      </h1>

      <div className="flex items-center gap-4 mb-8 flex-wrap">
        <span className="inline-block px-2.5 py-0.5 rounded text-xs font-bold bg-green-100 text-green-700">
          Java
        </span>
        <a
          href={`https://www.geeksforgeeks.org/problems/${problem.title.toLowerCase().replace(/\s+/g, '-').replace(/[^a-z0-9-]/g, '')}/1`}
          target="_blank"
          rel="nofollow noopener noreferrer"
          className="text-green-600 hover:underline text-sm"
        >
          View on GFG ↗
        </a>
      </div>

      <section className="mb-8">
        <h2 className="text-lg font-semibold mb-3">Java Solution</h2>
        <CodeBlock code={problem.code} lang="java" />
      </section>

      <AdUnit slot="YOUR_AD_SLOT" style="rectangle" className="mb-8" />

      <nav className="flex justify-between items-center border-t border-slate-200 pt-6 gap-3 flex-wrap">
        {prev ? (
          <Link
            href={`/gfg/${prev.slug}`}
            className="flex items-center gap-2 px-4 py-2 border border-slate-200 rounded-lg text-sm text-slate-700 hover:border-green-400 hover:text-green-600 transition-colors max-w-[46%] truncate"
          >
            ← {prev.title}
          </Link>
        ) : (
          <span />
        )}

        <Link
          href="/gfg"
          className="px-4 py-2 border border-slate-200 rounded-lg text-sm text-slate-500 hover:border-green-400 hover:text-green-600 transition-colors"
        >
          ☰ All GFG Problems
        </Link>

        {next ? (
          <Link
            href={`/gfg/${next.slug}`}
            className="flex items-center gap-2 px-4 py-2 border border-slate-200 rounded-lg text-sm text-slate-700 hover:border-green-400 hover:text-green-600 transition-colors max-w-[46%] truncate"
          >
            {next.title} →
          </Link>
        ) : (
          <span />
        )}
      </nav>
    </article>
  )
}
