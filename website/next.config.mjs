import { fileURLToPath } from 'url'
import path from 'path'

const __dirname = path.dirname(fileURLToPath(import.meta.url))

/** @type {import('next').NextConfig} */
const nextConfig = {
  // Allow Next.js to trace files from the parent solutions/ folder at build time
  experimental: {
    outputFileTracingRoot: path.join(__dirname, '../'),
  },
  // Redirect www → non-www so Google always indexes the canonical domain
  async redirects() {
    return [
      {
        source: '/:path*',
        has: [{ type: 'host', value: 'www.dsasolved.com' }],
        destination: 'https://dsasolved.com/:path*',
        permanent: true,
      },
    ]
  },
}

export default nextConfig
