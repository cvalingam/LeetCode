import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllGfgProblems, getGfgProblemBySlug, getAdjacentGfgProblems } from '@/lib/gfg-problems'
import { toLeetCodeSlug, SITE_URL } from '@/lib/constants'
import CodeBlockWithHeader from '@/components/CodeBlockWithHeader'
import AdUnit from '@/components/AdUnit'
import HelpfulWidget from '@/components/HelpfulWidget'

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
  let desc = `GeeksforGeeks ${problem.title} – Java solution`
  if (problem.approach) desc += `. ${problem.approach}`
  else desc += `. GFG Problem of the Day.`

  return {
    title,
    description: desc,
    alternates: { canonical: `/gfg/${problem.slug}` },
    openGraph: {
      title: `${title} — GFG Java Solution`,
      description: desc,
      type: 'article',
      url: `/gfg/${problem.slug}`,
    },
  }
}

export default async function GfgProblemPage({ params }: Props) {
  const problem = getGfgProblemBySlug(params.slug)
  if (!problem) notFound()

  const { prev, next } = getAdjacentGfgProblems(params.slug)
  const gfgSlug = toLeetCodeSlug(problem.title)
  let schemaDesc = `GeeksforGeeks ${problem.title} – Java solution`
  if (problem.approach) schemaDesc += `. ${problem.approach}`
  else schemaDesc += `. GFG Problem of the Day.`

  return (
    <article className="max-w-3xl mx-auto py-8">

      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{
          __html: JSON.stringify({
            '@context': 'https://schema.org',
            '@graph': [
              {
                '@type': 'TechArticle',
                headline: `${problem.title} — GFG Java Solution`,
                description: schemaDesc,
                author: { '@type': 'Person', name: 'Sivalingam Ramasamy', url: 'https://github.com/cvalingam' },
                url: `${SITE_URL}/gfg/${problem.slug}`,
                datePublished: '2025-01-01',
                dateModified: '2025-06-01',
                image: `${SITE_URL}/opengraph-image`,
                programmingLanguage: 'Java',
                proficiencyLevel: 'Beginner',
              },
              {
                '@type': 'BreadcrumbList',
                itemListElement: [
                  { '@type': 'ListItem', position: 1, name: 'GFG Solutions', item: `${SITE_URL}/gfg` },
                  { '@type': 'ListItem', position: 2, name: problem.title, item: `${SITE_URL}/gfg/${problem.slug}` },
                ],
              },
            ],
          }),
        }}
      />

      {/* Breadcrumb */}
      <nav className="flex items-center gap-1.5 text-xs text-gray-400 mb-6" aria-label="Breadcrumb">
        <Link href="/gfg" className="hover:text-emerald-600 transition-colors">GFG</Link>
        <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
        <span className="text-gray-600 font-medium truncate">{problem.title}</span>
      </nav>

      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-8" />

      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight text-gray-900 dark:text-gray-100 mb-3">
        {problem.title}
      </h1>

      <div className="flex items-center gap-3 mb-8 flex-wrap">
        <span className="inline-flex items-center gap-1.5 px-2.5 py-0.5 rounded-full text-xs font-medium text-orange-700 dark:text-orange-400 bg-orange-50 dark:bg-orange-950/60">
          <span className="w-1.5 h-1.5 rounded-full bg-orange-500" />
          Java
        </span>
        <span className="w-px h-4 bg-gray-200 dark:bg-gray-700" />
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

      {/* Approach */}
      {problem.approach && (
        <div className="mb-8 p-4 rounded-xl bg-slate-50 dark:bg-gray-800/50 border border-slate-100 dark:border-gray-800">
          <h2 className="text-[11px] font-semibold text-gray-400 dark:text-gray-500 uppercase tracking-wider mb-2">Approach</h2>
          <p className="text-sm text-gray-700 dark:text-gray-300 leading-relaxed">{problem.approach}</p>
        </div>
      )}

      {/* Complexity */}
      {problem.complexity && (
        <div className="flex flex-wrap gap-3 mb-8">
          <div className="inline-flex items-center gap-1.5 px-3 py-1 rounded-lg bg-emerald-50 border border-emerald-100 dark:bg-emerald-950/50 dark:border-emerald-900">
            <svg className="w-3.5 h-3.5 text-emerald-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <circle cx="12" cy="12" r="10" /><polyline points="12 6 12 12 16 14" />
            </svg>
            <span className="text-xs font-medium text-emerald-700 dark:text-emerald-300">Time: <span className="font-mono">{problem.complexity.time}</span></span>
          </div>
          <div className="inline-flex items-center gap-1.5 px-3 py-1 rounded-lg bg-violet-50 border border-violet-100 dark:bg-violet-950/50 dark:border-violet-900">
            <svg className="w-3.5 h-3.5 text-violet-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <line x1="8" y1="6" x2="21" y2="6" /><line x1="8" y1="12" x2="21" y2="12" /><line x1="8" y1="18" x2="21" y2="18" /><line x1="3" y1="6" x2="3.01" y2="6" /><line x1="3" y1="12" x2="3.01" y2="12" /><line x1="3" y1="18" x2="3.01" y2="18" />
            </svg>
            <span className="text-xs font-medium text-violet-700 dark:text-violet-300">Space: <span className="font-mono">{problem.complexity.space}</span></span>
          </div>
        </div>
      )}

      <section className="mb-8">
        <CodeBlockWithHeader
          code={problem.code}
          lang="java"
          filename={`${problem.title}.java`}
        />
      </section>

      <AdUnit slot="YOUR_AD_SLOT" style="rectangle" className="mb-6" />

      {/* Helpful widget */}
      <HelpfulWidget />

      <nav className="flex justify-between items-center border-t border-gray-100 dark:border-gray-800 pt-6 gap-3 flex-wrap" aria-label="Problem navigation">
        {prev ? (
          <Link
            href={`/gfg/${prev.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white dark:bg-gray-900 border border-gray-200 dark:border-gray-700 rounded-xl text-sm text-gray-700 dark:text-gray-300 hover:border-emerald-300 dark:hover:border-emerald-600 hover:bg-emerald-50/50 dark:hover:bg-emerald-950/30 hover:text-emerald-700 dark:hover:text-emerald-400 transition-all shadow-sm max-w-[46%]"
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
          className="px-4 py-2.5 bg-white dark:bg-gray-900 border border-gray-200 dark:border-gray-700 rounded-xl text-sm text-gray-500 dark:text-gray-400 hover:border-emerald-300 dark:hover:border-emerald-600 hover:text-emerald-600 dark:hover:text-emerald-400 transition-all shadow-sm hidden sm:block"
        >
          All GFG Problems
        </Link>

        {next ? (
          <Link
            href={`/gfg/${next.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white dark:bg-gray-900 border border-gray-200 dark:border-gray-700 rounded-xl text-sm text-gray-700 dark:text-gray-300 hover:border-emerald-300 dark:hover:border-emerald-600 hover:bg-emerald-50/50 dark:hover:bg-emerald-950/30 hover:text-emerald-700 dark:hover:text-emerald-400 transition-all shadow-sm max-w-[46%]"
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
