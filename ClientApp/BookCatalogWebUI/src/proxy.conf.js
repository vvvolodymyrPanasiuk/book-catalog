const PROXY_CONFIG = [
  {
    context: [
      "/",
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
