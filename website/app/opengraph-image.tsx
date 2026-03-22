import { ImageResponse } from 'next/og'

export const runtime = 'edge'
export const size = { width: 1200, height: 630 }
export const contentType = 'image/png'

export default function OgImage() {
  return new ImageResponse(
    (
      <div
        style={{
          background: 'linear-gradient(135deg, #4f46e5 0%, #7c3aed 100%)',
          width: '100%',
          height: '100%',
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'flex-start',
          justifyContent: 'center',
          padding: '80px',
        }}
      >
        <div style={{ display: 'flex', alignItems: 'center', gap: '20px', marginBottom: '32px' }}>
          <div
            style={{
              width: '72px',
              height: '72px',
              borderRadius: '16px',
              background: 'rgba(255,255,255,0.2)',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              fontSize: '40px',
              fontWeight: 900,
              color: 'white',
            }}
          >
            D
          </div>
          <span style={{ color: 'white', fontSize: '40px', fontWeight: 800 }}>DSA Solutions</span>
        </div>
        <div
          style={{
            color: 'white',
            fontSize: '60px',
            fontWeight: 800,
            lineHeight: 1.1,
            marginBottom: '24px',
          }}
        >
          LeetCode C# &amp; GFG Java
        </div>
        <div style={{ color: 'rgba(199,210,254,1)', fontSize: '30px', fontWeight: 400 }}>
          1300+ clean solutions · dsasolved.com
        </div>
      </div>
    ),
    { width: 1200, height: 630 }
  )
}
