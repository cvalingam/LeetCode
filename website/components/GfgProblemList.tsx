'use client'

import Link from 'next/link'
import { useEffect, useMemo, useState } from 'react'
import { useSearchParams } from 'next/navigation'
import type { GfgProblemMeta } from '@/lib/gfg-problems'
import AdUnit from './AdUnit'

export default function GfgProblemList({
  problems,
}: {
  problems: GfgProblemMeta[]
}) {
  const searchParams = useSearchParams()
  const initialQuery = searchParams.get('q') ?? ''
  const [search, setSearch] = useState(initialQuery)

  useEffect(() => { setSearch(initialQuery) }, [initialQuery])

  const filtered = useMemo(() => {
    const term = search.trim().toLowerCase()
    return !term ? problems : problems.filter(p => p.title.toLowerCase().includes(term))
  }, [problems, search])

  return (
    <>
      {/* Hero */}
      <section className="relative overflow-hidden rounded-2xl bg-gradient-to-br from-emerald-600 via-emerald-700 to-teal-700 px-6 py-10 mb-8 text-white shadow-lg">
        <div className="absolute inset-0 bg-[radial-gradient(ellipse_at_top_right,_rgba(255,255,255,0.1)_0%,_transparent_55%)] pointer-events-none" />
        <div className="relative">
          <div className="inline-flex items-center gap-2 bg-white/10 backdrop-blur-sm rounded-full px-3 py-1 text-xs font-medium mb-4">
            <span className="w-1.5 h-1.5 rounded-full bg-lime-300 animate-pulse" />
            POTD Solutions
          </div>
          <h1 className="text-3xl sm:text-4xl font-extrabold tracking-tight mb-2">
            GeeksforGeeks <span className="text-emerald-200">Java Solutions</span>
          </h1>
          <p className="text-emerald-200 text-sm sm:text-base mb-8 max-w-xl">
            Daily Problem of the Day solutions — clean Java code for every GFG POTD.
          </p>
          <div>
            <div className="text-2xl font-bold tabular-nums text-white">{problems.length}</div>
            <div className="text-[11px] uppercase tracking-widest mt-0.5 text-white/60">Solved</div>
          </div>
        </div>
      </section>

        <AdUnit slot="4545599910" style="leaderboard" className="mb-6" />

      {/* Search */}
      <div className="mb-4">
        <div className="relative max-w-sm">
          <svg
            className="absolute left-3 top-1/2 -translate-y-1/2 w-3.5 h-3.5 text-gray-400 pointer-events-none"
            fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2.5}
          >
            <path strokeLinecap="round" strokeLinejoin="round" d="M21 21l-4.35-4.35M17 11A6 6 0 1 1 5 11a6 6 0 0 1 12 0z" />
          </svg>
          <input
            type="text"
            value={search}
            onChange={e => setSearch(e.target.value)}
            placeholder="Search problems…"
            className="w-full pl-8 pr-3 py-2 text-sm border border-gray-200 dark:border-gray-700 rounded-lg bg-white dark:bg-gray-800 dark:text-gray-100 dark:placeholder-gray-500 focus:outline-none focus:border-emerald-400 focus:ring-2 focus:ring-emerald-100 dark:focus:ring-emerald-900 transition-all shadow-sm"
          />
        </div>
      </div>

      <p className="text-xs text-gray-400 dark:text-gray-500 mb-3 tabular-nums">
        {filtered.length} problem{filtered.length !== 1 ? 's' : ''}
      </p>

      {filtered.length === 0 ? (
        <div className="text-center py-20 text-gray-400 dark:text-gray-500">
          <div className="text-4xl mb-3">🔍</div>
          <p>No problems match your search.</p>
        </div>
      ) : (
        <div className="overflow-hidden rounded-xl border border-gray-200 dark:border-gray-700 shadow-sm bg-white dark:bg-gray-900">
          <table className="w-full text-sm">
            <thead>
              <tr className="border-b border-gray-100 dark:border-gray-800 bg-gray-50/80 dark:bg-gray-800/80">
                <th className="px-4 py-3 text-left text-[11px] font-semibold text-gray-400 dark:text-gray-500 uppercase tracking-wider w-12">#</th>
                <th className="px-4 py-3 text-left text-[11px] font-semibold text-gray-400 dark:text-gray-500 uppercase tracking-wider">Title</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-50 dark:divide-gray-800">
              {filtered.map((p, i) => (
                <tr key={p.slug} className="hover:bg-emerald-50/30 dark:hover:bg-emerald-950/20 transition-colors group">
                  <td className="px-4 py-3 text-gray-400 dark:text-gray-500 tabular-nums font-mono text-xs">{i + 1}</td>
                  <td className="px-4 py-3">
                    <Link
                      href={`/gfg/${p.slug}`}
                      className="font-medium text-gray-800 dark:text-gray-200 group-hover:text-emerald-600 dark:group-hover:text-emerald-400 transition-colors"
                    >
                      {p.title}
                    </Link>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </>
  )
}
