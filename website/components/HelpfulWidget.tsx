'use client'

import { useState } from 'react'

export default function HelpfulWidget() {
  const [vote, setVote] = useState<'up' | 'down' | null>(null)

  if (vote) {
    return (
      <div className="flex items-center gap-2 text-sm text-gray-500 py-4">
        <svg className="w-4 h-4 text-green-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M5 13l4 4L19 7" />
        </svg>
        Thanks for the feedback!
      </div>
    )
  }

  return (
    <div className="flex items-center gap-3 py-4 border-t border-gray-100">
      <span className="text-sm text-gray-500">Was this solution helpful?</span>
      <button
        onClick={() => setVote('up')}
        aria-label="Yes, helpful"
        className="inline-flex items-center gap-1.5 px-3 py-1.5 text-sm text-gray-600 bg-white border border-gray-200 rounded-lg hover:border-green-400 hover:text-green-600 hover:bg-green-50 transition-all"
      >
        <svg className="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M14 10h4.764a2 2 0 011.789 2.894l-3.5 7A2 2 0 0115.263 21h-4.017c-.163 0-.326-.02-.485-.06L7 20m7-10V5a2 2 0 00-2-2h-.095c-.5 0-.905.405-.905.905 0 .714-.211 1.412-.608 2.006L7 11v9m7-10h-2M7 20H5a2 2 0 01-2-2v-6a2 2 0 012-2h2.5" />
        </svg>
        Yes
      </button>
      <button
        onClick={() => setVote('down')}
        aria-label="No, not helpful"
        className="inline-flex items-center gap-1.5 px-3 py-1.5 text-sm text-gray-600 bg-white border border-gray-200 rounded-lg hover:border-red-400 hover:text-red-600 hover:bg-red-50 transition-all"
      >
        <svg className="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2}>
          <path strokeLinecap="round" strokeLinejoin="round" d="M10 14H5.236a2 2 0 01-1.789-2.894l3.5-7A2 2 0 018.736 3h4.018c.163 0 .326.02.485.06L17 4m-7 10v2a2 2 0 002 2h.095c.5 0 .905-.405.905-.905 0-.714.211-1.412.608-2.006L17 13V4m-7 10h2m5-10h2a2 2 0 012 2v6a2 2 0 01-2 2h-2.5" />
        </svg>
        No
      </button>
    </div>
  )
}
