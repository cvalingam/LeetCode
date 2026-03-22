import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import './globals.css'
import Header from '@/components/Header'
import Footer from '@/components/Footer'
import { SITE_URL } from '@/lib/constants'

const inter = Inter({
  subsets: ['latin'],
  variable: '--font-inter',
  display: 'swap',
})

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
    <html lang="en" className={inter.variable}>
      <head>
        {/* eslint-disable-next-line @next/next/no-sync-scripts */}
        <script
          async
          src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-5486715116636186"
          crossOrigin="anonymous"
        />
        {/* Microsoft Clarity */}
        <script
          dangerouslySetInnerHTML={{
            __html: `(function(c,l,a,r,i,t,y){c[a]=c[a]||function(){(c[a].q=c[a].q||[]).push(arguments)};t=l.createElement(r);t.async=1;t.src="https://www.clarity.ms/tag/"+i+"?ref=bwt";y=l.getElementsByTagName(r)[0];y.parentNode.insertBefore(t,y);})(window,document,"clarity","script","vzu51pq6gv");`,
          }}
        />
      </head>
      <body className="bg-gray-50 text-gray-900 antialiased flex flex-col min-h-screen font-sans">
        <Header />
        <main className="flex-1 max-w-5xl mx-auto w-full px-4 sm:px-6 pt-20 pb-16">
          {children}
        </main>
        <Footer />
      </body>
    </html>
  )
}
