import { notFound } from 'next/navigation'
import type { Metadata } from 'next'
import Link from 'next/link'
import { getAllTags, getProblemNumbersByTag, TAG_LABELS } from '@/lib/tags'
import { getAllProblemsMeta } from '@/lib/problems'
import DifficultyBadge from '@/components/DifficultyBadge'
import { SITE_URL } from '@/lib/constants'

interface Props {
  params: { tag: string }
}

export function generateStaticParams() {
  return getAllTags().map(({ tag }) => ({ tag }))
}

export const dynamicParams = false

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const label = TAG_LABELS[params.tag]
  if (!label) return {}
  const desc = `LeetCode C# solutions for ${label} problems — clean, readable C# code for every ${label} problem on LeetCode.`
  return {
    title: `${label} LeetCode Problems`,
    description: desc,
    alternates: { canonical: `/topics/${params.tag}` },
    openGraph: {
      title: `${label} LeetCode Problems — C# Solutions`,
      description: desc,
      url: `/topics/${params.tag}`,
      type: 'website',
    },
  }
}

export default function TopicPage({ params }: Props) {
  const label = TAG_LABELS[params.tag]
  if (!label) notFound()

  const numbers = getProblemNumbersByTag(params.tag)
  const allProblems = getAllProblemsMeta()
  const problemMap = new Map(allProblems.map(p => [p.number, p]))
  const problems = numbers.map(n => problemMap.get(n)).filter(Boolean) as typeof allProblems

  if (!problems.length) notFound()

  const jsonLd = {
    '@context': 'https://schema.org',
    '@graph': [
      {
        '@type': 'CollectionPage',
        name: `${label} LeetCode Problems`,
        description: `LeetCode C# solutions for ${label} problems`,
        url: `${SITE_URL}/topics/${params.tag}`,
        numberOfItems: problems.length,
      },
      {
        '@type': 'BreadcrumbList',
        itemListElement: [
          { '@type': 'ListItem', position: 1, name: 'LeetCode Solutions', item: SITE_URL },
          { '@type': 'ListItem', position: 2, name: 'Topics', item: `${SITE_URL}/topics` },
          { '@type': 'ListItem', position: 3, name: label, item: `${SITE_URL}/topics/${params.tag}` },
        ],
      },
    ],
  }

  return (
    <div className="max-w-3xl mx-auto py-8">
      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{ __html: JSON.stringify(jsonLd) }}
      />

      {/* Breadcrumb */}
      <nav className="flex items-center gap-1.5 text-xs text-gray-400 mb-6" aria-label="Breadcrumb">
        <Link href="/" className="hover:text-indigo-600 transition-colors">LeetCode</Link>
        <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
        <Link href="/topics" className="hover:text-indigo-600 transition-colors">Topics</Link>
        <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
        <span className="text-gray-600 font-medium">{label}</span>
      </nav>

      <h1 className="text-2xl sm:text-3xl font-bold tracking-tight text-gray-900 dark:text-gray-100 mb-1">
        {label}
      </h1>
      <p className="text-gray-500 dark:text-gray-400 text-sm mb-7">{problems.length} problems</p>

      <ul className="divide-y divide-gray-100 dark:divide-gray-800">
        {problems.map(p => (
          <li key={p.slug}>
            <Link
              href={`/problems/${p.slug}`}
              className="flex items-center justify-between py-3 gap-3 group hover:bg-gray-50/60 dark:hover:bg-gray-800/40 px-1 rounded-lg transition-colors"
            >
              <span className="flex items-center gap-3 min-w-0">
                <span className="w-10 text-right shrink-0 text-xs text-gray-400 dark:text-gray-500 font-mono tabular-nums">
                  {p.number}.
                </span>
                <span className="text-sm font-medium text-gray-800 dark:text-gray-200 group-hover:text-indigo-700 dark:group-hover:text-indigo-400 transition-colors truncate">
                  {p.title}
                </span>
              </span>
              <DifficultyBadge difficulty={p.difficulty} />
            </Link>
          </li>
        ))}
      </ul>
    </div>
  )
}
