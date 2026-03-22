'use client'

import Link from 'next/link'
import { useMemo, useState } from 'react'
import type { GfgProblemMeta } from '@/lib/gfg-problems'
import AdUnit from './AdUnit'

export default function GfgProblemList({
  problems,
  initialQuery = '',
}: {
  problems: GfgProblemMeta[]
  initialQuery?: string
}) {
  const [search, setSearch] = useState(initialQuery)

  const filtered = useMemo(() => {
    const term = search.trim().toLowerCase()
    return !term ? problems : problems.filter(p => p.title.toLowerCase().includes(term))
  }, [problems, search])

  return (
    <>
      {/* Hero */}
      <section className="text-center py-10">
        <h1 className="text-3xl sm:text-4xl font-extrabold tracking-tight mb-2">
          GeeksforGeeks <span className="text-green-600">Java</span> Solutions
        </h1>
        <p className="text-slate-500 mb-6">
          Daily Problem of the Day solutions — clean Java code for every GFG POTD.
        </p>
        <div className="flex justify-center gap-10">
          <div className="text-center">
            <div className="text-3xl font-bold text-green-600">{problems.length}</div>
            <div className="text-xs text-slate-400 uppercase tracking-widest mt-1">Solved</div>
          </div>
        </div>
      </section>

      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-6" />

      {/* Search */}
      <div className="mb-4">
        <input
          type="text"
          value={search}
          onChange={e => setSearch(e.target.value)}
          placeholder="Search problems…"
          className="w-full max-w-sm px-3 py-1.5 text-sm border border-slate-200 rounded-md focus:outline-none focus:border-green-500 bg-slate-50 focus:bg-white transition-colors"
        />
      </div>

      <p className="text-sm text-slate-400 mb-3">
        Showing {filtered.length} problem{filtered.length !== 1 ? 's' : ''}
      </p>

      {filtered.length === 0 ? (
        <div className="text-center py-20 text-slate-400">No problems match your search.</div>
      ) : (
        <div className="overflow-x-auto rounded-lg border border-slate-200">
          <table className="w-full text-sm">
            <thead className="bg-slate-50 text-xs uppercase text-slate-400 tracking-wide">
              <tr>
                <th className="px-4 py-3 text-left w-12">#</th>
                <th className="px-4 py-3 text-left">Title</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filtered.map((p, i) => (
                <tr key={p.slug} className="hover:bg-slate-50 transition-colors">
                  <td className="px-4 py-2.5 text-slate-400">{i + 1}</td>
                  <td className="px-4 py-2.5">
                    <Link
                      href={`/gfg/${p.slug}`}
                      className="font-medium text-slate-800 hover:text-green-600 transition-colors"
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
