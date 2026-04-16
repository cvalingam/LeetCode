import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllProblems, getProblemBySlug, getAdjacentProblems } from '@/lib/problems'
import { toLeetCodeSlug, SITE_URL } from '@/lib/constants'
import { TAG_LABELS } from '@/lib/tags'
import CodeBlockWithHeader, { type SupportedLang } from '@/components/CodeBlockWithHeader'
import LanguageTabs from '@/components/LanguageTabs'
import DifficultyBadge from '@/components/DifficultyBadge'
import AdUnit from '@/components/AdUnit'
import HelpfulWidget from '@/components/HelpfulWidget'

const EXT_TO_SHIKI: Record<string, SupportedLang> = {
  cs:   'csharp',
  java: 'java',
  sql:  'sql',
  ts:   'typescript',
  go:   'go',
  cpp:  'cpp',
  py:   'python',
  sh:   'bash',
}

interface Props {
  params: { slug: string }
}

// Tell Next.js which slugs to pre-render at build time
export async function generateStaticParams() {
  return getAllProblems().map(p => ({ slug: p.slug }))
}

// No dynamic pages at runtime — 404 for unknown slugs
export const dynamicParams = false

const EXT_TO_LABEL: Record<string, string> = {
  cs: 'C#', java: 'Java', sql: 'MySQL', ts: 'TypeScript',
  go: 'Go', cpp: 'C++', py: 'Python', sh: 'Shell',
}

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const problem = getProblemBySlug(params.slug)
  if (!problem) return {}

  const primaryLabel = EXT_TO_LABEL[problem.primaryExt] ?? problem.primaryExt.toUpperCase()
  const allLabels = [primaryLabel, ...Object.keys(problem.extraCodes ?? {}).map(e => EXT_TO_LABEL[e] ?? e)].join(', ')
  const title = `${problem.number}. ${problem.title}`
  let desc = `LeetCode ${problem.number} ${problem.title} – ${problem.difficulty} ${allLabels} solution`
  if (problem.approach) desc += `. ${problem.approach.split('\n')[0]}`
  if (problem.complexity) desc += `. Time: ${problem.complexity.time}, Space: ${problem.complexity.space}.`
  else desc += `.`

  return {
    title,
    description: desc,
    alternates: {
      canonical: `/problems/${problem.slug}`,
    },
    openGraph: {
      title: `${title} — LeetCode ${primaryLabel} Solution`,
      description: desc,
      type: 'article',
      url: `/problems/${problem.slug}`,
    },
  }
}

export default async function ProblemPage({ params }: Props) {
  const problem = getProblemBySlug(params.slug)
  if (!problem) notFound()

  const { prev, next } = getAdjacentProblems(params.slug)
  const lcSlug = toLeetCodeSlug(problem.title)
  const primaryLabel = EXT_TO_LABEL[problem.primaryExt] ?? problem.primaryExt.toUpperCase()
  const allLabels = [primaryLabel, ...Object.keys(problem.extraCodes ?? {}).map(e => EXT_TO_LABEL[e] ?? e)].join(', ')
  const schemaTitle = `${problem.number}. ${problem.title} — LeetCode ${primaryLabel} Solution`
  let schemaDesc = `LeetCode ${problem.number} ${problem.title} – ${problem.difficulty} ${allLabels} solution`
  if (problem.approach) schemaDesc += `. ${problem.approach}`
  if (problem.complexity) schemaDesc += `. Time: ${problem.complexity.time}, Space: ${problem.complexity.space}.`
  else schemaDesc += `.`

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
                headline: schemaTitle,
                description: schemaDesc,
                author: { '@type': 'Person', name: 'Sivalingam Ramasamy', url: 'https://github.com/cvalingam' },
                url: `${SITE_URL}/problems/${problem.slug}`,
                datePublished: '2024-01-01',
                dateModified: '2025-06-01',
                image: `${SITE_URL}/opengraph-image`,
                programmingLanguage: primaryLabel,
                proficiencyLevel: 'Beginner',
              },
              {
                '@type': 'BreadcrumbList',
                itemListElement: [
                  { '@type': 'ListItem', position: 1, name: 'LeetCode Solutions', item: SITE_URL },
                  { '@type': 'ListItem', position: 2, name: `${problem.number}. ${problem.title}`, item: `${SITE_URL}/problems/${problem.slug}` },
                ],
              },
            ],
          }),
        }}
      />

      {/* Breadcrumb */}
      <nav className="flex items-center gap-1.5 text-xs text-gray-400 mb-6" aria-label="Breadcrumb">
        <Link href="/" className="hover:text-indigo-600 transition-colors">LeetCode</Link>
        <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
        <span className="text-gray-600 font-medium truncate">{problem.number}. {problem.title}</span>
      </nav>

      {/* Ad: leaderboard */}
      <AdUnit slot="4545599910" style="leaderboard" className="mb-8" />

      {/* Title */}
      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight text-gray-900 dark:text-gray-100 mb-3">
        {problem.number}. {problem.title}
      </h1>

      {/* Meta row */}
      <div className="flex items-center gap-3 mb-5 flex-wrap">
        <DifficultyBadge difficulty={problem.difficulty} />
        <span className="w-px h-4 bg-gray-200 dark:bg-gray-700" />
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

      {/* Tags */}
      {problem.tags.length > 0 && (
        <div className="flex flex-wrap gap-1.5 mb-8">
          {problem.tags.map(tag => (
            <a
              key={tag}
              href={`/topics/${tag}`}
              className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium text-indigo-700 bg-indigo-50 hover:bg-indigo-100 hover:text-indigo-900 transition-colors border border-indigo-100 dark:bg-indigo-950 dark:text-indigo-300 dark:border-indigo-800 dark:hover:bg-indigo-900"
            >
              {TAG_LABELS[tag] ?? tag}
            </a>
          ))}
        </div>
      )}

      {/* Complexity */}
      {problem.complexity && (
        <div className="flex flex-wrap gap-3 mb-8">
          <div className="inline-flex items-center gap-1.5 px-3 py-1 rounded-lg bg-emerald-50 border border-emerald-100 dark:bg-emerald-950/50 dark:border-emerald-900">
            <svg className="w-3.5 h-3.5 text-emerald-600 dark:text-emerald-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <path strokeLinecap="round" strokeLinejoin="round" d="M12 6v6l4 2" />
              <circle cx="12" cy="12" r="10" />
            </svg>
            <span className="text-xs font-medium text-emerald-700 dark:text-emerald-300">Time: <span className="font-mono">{problem.complexity.time}</span></span>
          </div>
          <div className="inline-flex items-center gap-1.5 px-3 py-1 rounded-lg bg-violet-50 border border-violet-100 dark:bg-violet-950/50 dark:border-violet-900">
            <svg className="w-3.5 h-3.5 text-violet-600 dark:text-violet-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
              <path strokeLinecap="round" strokeLinejoin="round" d="M4 7h16M4 12h10M4 17h6" />
            </svg>
            <span className="text-xs font-medium text-violet-700 dark:text-violet-300">Space: <span className="font-mono">{problem.complexity.space}</span></span>
          </div>
        </div>
      )}

      {/* Approach */}
      {problem.approach && (
        <div className="mb-8 p-4 rounded-xl bg-slate-50 dark:bg-gray-800/50 border border-slate-100 dark:border-gray-800">
          <h2 className="text-[11px] font-semibold text-gray-400 dark:text-gray-500 uppercase tracking-wider mb-3">Explanation</h2>
          {problem.approach.split('\n').map((para, i) => (
            <p key={i} className="text-sm text-gray-700 dark:text-gray-300 leading-relaxed mb-2 last:mb-0">{para}</p>
          ))}
        </div>
      )}

      {/* Code */}
      <section className="mb-8">
        {problem.extraCodes && Object.keys(problem.extraCodes).length > 0 ? (
          <LanguageTabs extensions={[problem.primaryExt, ...Object.keys(problem.extraCodes)]}>
            <CodeBlockWithHeader
              code={problem.code}
              lang={EXT_TO_SHIKI[problem.primaryExt] ?? 'csharp'}
              filename={`${problem.number}.${problem.primaryExt}`}
            />
            {Object.entries(problem.extraCodes).map(([ext, code]) => (
              <CodeBlockWithHeader
                key={ext}
                code={code}
                lang={EXT_TO_SHIKI[ext] ?? 'csharp'}
                filename={`${problem.number}.${ext}`}
              />
            ))}
          </LanguageTabs>
        ) : (
          <CodeBlockWithHeader
            code={problem.code}
            lang={EXT_TO_SHIKI[problem.primaryExt] ?? 'csharp'}
            filename={`${problem.number}.${problem.primaryExt}`}
          />
        )}
      </section>

      {/* Ad: rectangle */}
        <AdUnit slot="1364902808" style="rectangle" className="mb-6" />

      {/* Helpful widget */}
      <HelpfulWidget />

      {/* Prev / Next navigation */}
      <nav className="flex justify-between items-center border-t border-gray-100 dark:border-gray-800 pt-6 gap-3 flex-wrap" aria-label="Problem navigation">
        {prev ? (
          <Link
            href={`/problems/${prev.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white dark:bg-gray-900 border border-gray-200 dark:border-gray-700 rounded-xl text-sm text-gray-700 dark:text-gray-300 hover:border-indigo-300 dark:hover:border-indigo-600 hover:bg-indigo-50/50 dark:hover:bg-indigo-950/30 hover:text-indigo-700 dark:hover:text-indigo-400 transition-all shadow-sm max-w-[46%]"
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
          className="px-4 py-2.5 bg-white dark:bg-gray-900 border border-gray-200 dark:border-gray-700 rounded-xl text-sm text-gray-500 dark:text-gray-400 hover:border-indigo-300 dark:hover:border-indigo-600 hover:text-indigo-600 dark:hover:text-indigo-400 transition-all shadow-sm hidden sm:block"
        >
          All Problems
        </Link>

        {next ? (
          <Link
            href={`/problems/${next.slug}`}
            className="group flex items-center gap-2 px-4 py-2.5 bg-white dark:bg-gray-900 border border-gray-200 dark:border-gray-700 rounded-xl text-sm text-gray-700 dark:text-gray-300 hover:border-indigo-300 dark:hover:border-indigo-600 hover:bg-indigo-50/50 dark:hover:bg-indigo-950/30 hover:text-indigo-700 dark:hover:text-indigo-400 transition-all shadow-sm max-w-[46%]"
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
