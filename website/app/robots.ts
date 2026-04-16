import { MetadataRoute } from 'next'
import { SITE_URL } from '@/lib/constants'

export default function robots(): MetadataRoute.Robots {
  return {
    rules: [
      {
        userAgent: '*',
        allow: '/',
        disallow: ['/*?q=', '/_next/static/', '/*?dpl='],
      },
      // Explicitly allow OpenAI / ChatGPT crawlers
      { userAgent: 'GPTBot',         allow: '/' },
      { userAgent: 'OAI-SearchBot',  allow: '/' },
      { userAgent: 'ChatGPT-User',   allow: '/' },
      // Explicitly allow other AI crawlers
      { userAgent: 'Claude-Web',          allow: '/' },
      { userAgent: 'anthropic-ai',        allow: '/' },
      { userAgent: 'PerplexityBot',       allow: '/' },
      { userAgent: 'Googlebot-Extended',  allow: '/' },
      { userAgent: 'GoogleOther',         allow: '/' },
      { userAgent: 'Meta-ExternalAgent',  allow: '/' },
      { userAgent: 'cohere-ai',           allow: '/' },
      { userAgent: 'YouBot',              allow: '/' },
      { userAgent: 'Applebot-Extended',   allow: '/' },
    ],
    sitemap: `${SITE_URL}/sitemap.xml`,
  }
}
