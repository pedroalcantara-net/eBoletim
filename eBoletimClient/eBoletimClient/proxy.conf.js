const PROXY_CONFIG = [
  {
    context: ["/api"],
    target: "https://localhost:5001/",
    secure: false,
    logLevel: "debug",
    pathRewrite: {'^/api':''}
  },
];

module.exports = PROXY_CONFIG;
