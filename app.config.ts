// app.config.ts
import { defineConfig } from "@tanstack/start/config";
import path from "node:path";
import viteTsConfigPaths from "vite-tsconfig-paths";

const __dirname = import.meta.dirname;

export default defineConfig({
  // https://tanstack.com/router/latest/docs/framework/react/start/hosting/#nodejs
  server: {
    preset: "node-server",
    alias: {
      "@/*": path.resolve(__dirname, "./app/*"),
    },
  },
  // https://tanstack.com/router/latest/docs/framework/react/start/path-aliases
  vite: {
    plugins: [
      // this is the plugin that enables path aliases
      viteTsConfigPaths({
        projects: ["./tsconfig.json"],
      }),
    ],
  },
});
