/**
 * AdUnit — replace the `slot` prop with your real AdSense ad unit ID
 * after your site is approved by Google AdSense.
 *
 * Usage:
 *   <AdUnit slot="1234567890" style="leaderboard" />
 *   <AdUnit slot="1234567890" style="rectangle" />
 *
 * Until you have a real slot, this renders a visible placeholder so layout
 * is preserved during development.
 */

'use client'

import { useEffect } from 'react'

const ADSENSE_CLIENT = process.env.NEXT_PUBLIC_ADSENSE_CLIENT ?? ''

interface Props {
  slot: string
  style?: 'leaderboard' | 'rectangle'
  className?: string
}

const heights: Record<NonNullable<Props['style']>, string> = {
  leaderboard: 'h-24',
  rectangle:   'h-64',
}

export default function AdUnit({ slot, style = 'leaderboard', className = '' }: Props) {
  useEffect(() => {
    if (!ADSENSE_CLIENT || slot === 'YOUR_AD_SLOT') return
    try {
      // @ts-expect-error adsbygoogle is injected by Google's script
      ;(window.adsbygoogle = window.adsbygoogle || []).push({})
    } catch {
      // silently ignore — script not yet loaded
    }
  }, [slot])

  // Placeholder until AdSense is configured
  if (!ADSENSE_CLIENT || slot === 'YOUR_AD_SLOT') {
    return (
      <div
        className={`border border-dashed border-slate-200 bg-slate-50 rounded-lg flex items-center justify-center text-slate-400 text-xs ${heights[style]} ${className}`}
      >
        Advertisement
      </div>
    )
  }

  return (
    <ins
      className={`adsbygoogle block ${heights[style]} ${className}`}
      data-ad-client={ADSENSE_CLIENT}
      data-ad-slot={slot}
      data-ad-format="auto"
      data-full-width-responsive="true"
    />
  )
}
