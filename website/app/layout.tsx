import type { Metadata } from 'next'
import './globals.css'
import Header from '@/components/Header'
import Footer from '@/components/Footer'
import { SITE_URL } from '@/lib/constants'

export const metadata: Metadata = {
  metadataBase: new URL(SITE_URL),
  title: {
    default: 'DSA Solutions — LeetCode C# & GFG Java',
    template: '%s | DSA Solutions',
  },
  description:
    'Clean, readable C# and Java solutions to 800+ LeetCode and 500+ GeeksforGeeks problems. Built for developers preparing for coding interviews.',
  keywords: ['LeetCode', 'GeeksforGeeks', 'GFG', 'C#', 'csharp', 'Java', '.NET', 'solutions', 'interview prep', 'algorithms', 'data structures'],
  authors: [{ name: 'Sivalingam Ramasamy', url: 'https://github.com/cvalingam' }],
  openGraph: {
    type: 'website',
    locale: 'en_US',
    siteName: 'DSA Solutions',
  },
  twitter: {
    card: 'summary',
  },
  robots: {
    index: true,
    follow: true,
  },
}

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body className="bg-white text-slate-900 antialiased flex flex-col min-h-screen">
        <Header />
        <main className="flex-1 max-w-5xl mx-auto w-full px-4 sm:px-6 pt-20 pb-16">
          {children}
        </main>
        <Footer />
      </body>
    </html>
  )
}
