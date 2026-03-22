import Link from 'next/link'
import { getAllProblemsMeta } from '@/lib/problems'
import { getAllGfgProblemsMeta } from '@/lib/gfg-problems'

export default function Footer() {
  const lcCount  = getAllProblemsMeta().length
  const gfgCount = getAllGfgProblemsMeta().length
  const total    = lcCount + gfgCount
  return (
    <footer className="bg-white border-t border-gray-100 mt-auto">
      <div className="max-w-5xl mx-auto px-4 sm:px-6 py-10">

        <div className="grid grid-cols-1 sm:grid-cols-3 gap-8 mb-8">

          {/* Brand */}
          <div>
            <div className="flex items-center gap-2 mb-3">
              <span className="w-7 h-7 rounded-lg bg-gradient-to-br from-indigo-500 to-violet-600 text-white text-[11px] flex items-center justify-center font-black shadow-sm">
                D
              </span>
              <span className="font-extrabold text-gray-900 text-sm">DSA Solutions</span>
            </div>
            <p className="text-xs text-gray-500 leading-relaxed max-w-[220px]">
              Clean C# &amp; Java solutions to {total}+ coding problems. Built for developers cracking the interview.
            </p>
          </div>

          {/* LeetCode */}
          <div>
            <h3 className="text-[11px] font-semibold text-gray-400 uppercase tracking-wider mb-3">LeetCode C#</h3>
            <ul className="space-y-2">
              <li><Link href="/"       className="text-sm text-gray-500 hover:text-indigo-600 transition-colors">All Problems</Link></li>
              <li><Link href="/about"  className="text-sm text-gray-500 hover:text-indigo-600 transition-colors">About</Link></li>
              <li><Link href="/contact" className="text-sm text-gray-500 hover:text-indigo-600 transition-colors">Contact</Link></li>
            </ul>
          </div>

          {/* Resources */}
          <div>
            <h3 className="text-[11px] font-semibold text-gray-400 uppercase tracking-wider mb-3">Resources</h3>
            <ul className="space-y-2">
              <li><Link href="/gfg" className="text-sm text-gray-500 hover:text-emerald-600 transition-colors">GFG Java Solutions</Link></li>
              <li><Link href="/privacy-policy" className="text-sm text-gray-500 hover:text-indigo-600 transition-colors">Privacy Policy</Link></li>
              <li>
                <a
                  href="https://github.com/cvalingam/DSA-Solutions"
                  target="_blank"
                  rel="noopener noreferrer"
                  className="text-sm text-gray-500 hover:text-indigo-600 transition-colors inline-flex items-center gap-1"
                >
                  GitHub
                  <svg className="w-3 h-3" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
                    <path strokeLinecap="round" strokeLinejoin="round" d="M10 6H6a2 2 0 00-2 2v10a2 2 0 002 2h10a2 2 0 002-2v-4M14 4h6m0 0v6m0-6L10 14" />
                  </svg>
                </a>
              </li>
            </ul>
          </div>

        </div>

        <div className="border-t border-gray-100 pt-6 text-xs text-gray-400 text-center">
          &copy; {new Date().getFullYear()} Sivalingam Ramasamy &middot; DSA Solutions
        </div>

      </div>
    </footer>
  )
}
