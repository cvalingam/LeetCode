import { NextResponse } from 'next/server'
import type { NextRequest } from 'next/server'

// 301-redirect old slug-based URLs (/problems/1-two-sum) to number-only (/problems/1)
export function middleware(request: NextRequest) {
  const m = request.nextUrl.pathname.match(/^\/problems\/(\d+)-/)
  if (m) {
    return NextResponse.redirect(new URL(`/problems/${m[1]}`, request.url), 301)
  }
  return NextResponse.next()
}

export const config = {
  matcher: '/problems/:path*',
}
