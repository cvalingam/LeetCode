import Link from 'next/link'

export default function Footer() {
  return (
    <footer className="border-t border-slate-200 py-8 text-center text-slate-400 text-sm">
      <nav className="flex justify-center gap-5 mb-3">
        <Link href="/"               className="hover:text-blue-600 transition-colors">LeetCode</Link>
        <Link href="/gfg"            className="hover:text-green-600 transition-colors">GFG</Link>
        <Link href="/about"          className="hover:text-blue-600 transition-colors">About</Link>
        <Link href="/privacy-policy" className="hover:text-blue-600 transition-colors">Privacy Policy</Link>
        <Link href="/contact"        className="hover:text-blue-600 transition-colors">Contact</Link>
        <a
          href="https://github.com/cvalingam/DSA-Solutions"
          target="_blank"
          rel="noopener noreferrer"
          className="hover:text-blue-600 transition-colors"
        >
          GitHub
        </a>
      </nav>
      <p>&copy; {new Date().getFullYear()} Sivalingam Ramasamy &middot; DSA Solutions</p>
    </footer>
  )
}
