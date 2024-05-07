/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        "gray-20" : "#F8F4EB",
        "primary-white": "#F4FAFF",
        "primary-green-blue" : "#2D5872",
        "primary-dark-blue": "#0A2430",
      },
      backgroundImage : ( theme ) => ({
        "bg-pattern": "url('./assets/bg.png')",
        "gradient-bluewhite" : "radial-gradient(circle, #2D5872 0%, #F4FAFF 100%)",
      }),
      fontFamily: {
        lato: ["Lato", "sans-serif"],
        roboto: ["Roboto", "sans-serif"],
      },
      content: {
        "wallet": "url('./assets/wallet.png')",
        "logofooter": "url('./assets/calendar.png')",
      },
      minHeight: {
        "1/2" : "50vh",
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