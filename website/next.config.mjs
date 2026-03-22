import { fileURLToPath } from 'url'
import path from 'path'

const __dirname = path.dirname(fileURLToPath(import.meta.url))

/** @type {import('next').NextConfig} */
const nextConfig = {
  // Allow Next.js to trace files from the parent solutions/ folder at build time
  experimental: {
    outputFileTracingRoot: path.join(__dirname, '../'),
  },
  // Uncomment if you ever want a static export for GitHub Pages:
  // output: 'export',
}

export default nextConfig
