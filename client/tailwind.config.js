/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        "white": "#F4FAFF",
        "green-blue" : "#2D5872",
        "dark-blue": "#0A2430",
      },
      backgroundImage : ( theme ) => ({
        "bg-pattern": "url('./assets/bg.png')",
      }),
      fontFamily: {
        
      },
      content: {
        "wallet": "url('./assets/wallet.png')",
        "logofooter": "url('./assets/calendar.png')",
      }
    },
    screens : {
      xs : "480px",
      sm : "768px",
      md: "1070px",
    }
  },
  plugins: [],
}