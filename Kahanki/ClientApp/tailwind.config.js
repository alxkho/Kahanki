/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["src/**/*.{html,ts}"],
  blocklist: [
    "collapse"
  ],
  theme: {
    colors: {
      'blue': '#1fb6ff',
      'purple': '#7e5bef',
      'pink': '#ff49db',
      'orange': '#ff7849',
      'green': '#13ce66',
      'yellow': '#ffc82c',
      'gray-dark': '#273444',
      'gray': '#8492a6',
      'gray-light': '#d3dce6',
    },
    fontFamily: {
      sans: ['Graphik', 'sans-serif'],
      serif: ['Merriweather', 'serif'],
    },
    fontSize: {
      ssm: ['10px', '20px'],
      lgg: ['40px', '35px']
    },
    extend: {
      spacing: {
        '600px': '600px'
      },
      minWidth: {
        '4/12': '33.333333%;',
      },
      maxWidth: {
        '3/4': '75%;',
      }
    }
  },
  plugins: [],
  
}
