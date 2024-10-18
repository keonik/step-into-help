// app.config.ts
import { defineConfig } from "@tanstack/start/config";

export default defineConfig({
  // https://tanstack.com/router/latest/docs/framework/react/start/hosting/#nodejs
  server: {
    preset: "node-server",
  },
});
