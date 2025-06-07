/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    './Views/**/*.cshtml', // Razor
    './wwwroot/**/*.html', // HTML
    './Scripts/**/*.js',   // JavaScript
  ],
  theme: {
    extend: {
      fontFamily: {
        sans: ['Inter', 'ui-sans-serif', 'system-ui', 'sans-serif'],
      },
      colors: {
        accent: {
          pink: '#ff2d8b',
          violet: '#a043ff',
          cyan: '#17d4fc',
        },
      },
      keyframes: {
        float: {
          '0%, 100%': { transform: 'translateY(0)' },
          '50%': { transform: 'translateY(-10px)' },
        },
      },
      animation: {
        float: 'float 6s ease-in-out infinite',
      },
    },
  },
  plugins: [],
}

